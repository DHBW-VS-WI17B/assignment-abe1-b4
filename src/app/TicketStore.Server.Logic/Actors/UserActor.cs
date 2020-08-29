using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using TicketStore.Server.Logic.DataAccess.Contracts;
using TicketStore.Server.Logic.Messages.Requests;
using TicketStore.Server.Logic.Messages.Responses;
using TicketStore.Server.Logic.Util;
using TicketStore.Shared.Enums;
using TicketStore.Shared.Messages;
using TicketStore.Shared.Models;

namespace TicketStore.Server.Logic.Actors
{
    /// <summary>
    /// User actor. Handles all user related requests. Has no write access to the database. Can be instantiated multiple times.
    /// </summary>
    public class UserActor : ReceiveActor, ILogReceive
    {
        private readonly ILoggingAdapter _logger = Context.GetLogger();
        private readonly ActorSelection _writeToDbActorRef;
        private readonly IReadonlyRepositoryWrapper _repo;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repoWrapper">Readonly wrapper around all data repositories.</param>
        /// <param name="writeToDbActorRef">Reference to an actor with write access to the database.</param>
        public UserActor(IReadonlyRepositoryWrapper repoWrapper, ActorSelection writeToDbActorRef)
        {
            _repo = repoWrapper;
            _writeToDbActorRef = writeToDbActorRef;

            // register message handlers
            ReceiveAsync<CreateUserRequest>(ProcessMessageAsync);
            Receive<GetPurchasedTicketsRequest>(ProcessMessage);
            Receive<GetRemainingBudgetForCurrentYearRequest>(ProcessMessage);
            Receive<HandshakeRequest>(ProcessMessage);
        }

        /// <summary>
        /// Processes a create user request message. Forwards the message to the db actor with write access.
        /// </summary>
        /// <param name="msg">Immutable create user request message.</param>
        /// <returns></returns>
        private async Task ProcessMessageAsync(CreateUserRequest msg)
        {
            // akka is not able to remember the sender after an async operation.
            var sender = Sender;

            var addUserToDbResponse = await _writeToDbActorRef.Ask<AddUserToDbResponse>(new AddUserToDbRequest(msg.RequestId, msg.UserDto)).ConfigureAwait(false);

            if (addUserToDbResponse.Successful)
            {
                _logger.Info("Adding user to db succeded. New user id: {userId}", addUserToDbResponse.UserDto.Id);
                sender.Tell(new CreateUserSuccess(msg.RequestId, addUserToDbResponse.UserDto));
            }
            else
            {
                _logger.Info("Adding user to db failed. Reason: {err}", addUserToDbResponse.ErrorMessage);
                sender.Tell(new ErrorMessage(msg.RequestId, addUserToDbResponse.ErrorMessage));
            }
        }

        /// <summary>
        /// Processes a get purchased tickets request message.
        /// </summary>
        /// <param name="msg">Immutable get purchased tickets request message.</param>
        private void ProcessMessage(GetPurchasedTicketsRequest msg)
        {
            var purchasedTickets = _repo.Tickets.FindByCondition(t => t.UserId == msg.UserId).ToImmutableList();

            if (purchasedTickets.Count == 0)
            {
                _logger.Info("There are no ticket purchases for user with id {userId}", msg.UserId);
                Sender.Tell(new ErrorMessage(msg.RequestId, $"There are no ticket purchases for user with id {msg.UserId}"));
                return;
            }

            var enrichedTickets = purchasedTickets.Select(t => new RichTicketDto(t.Id, t.PurchaseDate, t.UserId, Mapper.EventToEventDto(_repo.Events.FindByCondition(e => e.Id == t.EventId).FirstOrDefault()))).ToImmutableList();
            var filteredTickets = FilterRichTicketDtos(enrichedTickets, msg.TicketFilter);
            var sortedTickets = SortRichTicketDtos(filteredTickets, msg.TicketSorting);

            _logger.Info("Found and ordered {count} tickets for user with id {userid}.", sortedTickets.Count, msg.UserId);
            Sender.Tell(new GetPurchasedTicketsSuccess(msg.RequestId, sortedTickets));
        }

        /// <summary>
        /// Processes a get remaining budget for current year request message.
        /// </summary>
        /// <param name="msg">Immutable a get remaining budget for current year request message.</param>
        private void ProcessMessage(GetRemainingBudgetForCurrentYearRequest msg)
        {
            if (!_repo.Users.FindByCondition(u => u.Id == msg.UserId).Any())
            {
                _logger.Warning("No user with id {userId} found. Can not retrieve a remaining budget.", msg.UserId);
                Sender.Tell(new ErrorMessage(Guid.NewGuid(), $"No user with id {msg.UserId} found. Can not retrieve a remaining budget."));
                return;
            }

            double spentOnEvents = 0;
            if (_repo.Tickets.FindByCondition(t => t.UserId == msg.UserId).Any())
            {
                var eventIds = _repo.Tickets.FindByCondition(t => t.UserId == msg.UserId).Select(t => t.EventId).ToList();
                var events = eventIds.Select(id => _repo.Events.FindByCondition(e => e.Id == id).FirstOrDefault()).ToList();
                spentOnEvents = events.Where(e => e.Date.Year == DateTime.Now.Year).Sum(x => x.PricePerTicket);
            }
            var budget = _repo.Users.FindByCondition(u => u.Id == msg.UserId).FirstOrDefault().YearlyBudget;
            var remainingBudget = budget - spentOnEvents;

            Sender.Tell(new GetRemainingBudgetForCurrentYearSuccess(remainingBudget, budget));
        }

        /// <summary>
        /// Processes a handshake request. Sends a response.
        /// </summary>
        /// <param name="msg">Immutable handshake request.</param>
        private void ProcessMessage(HandshakeRequest msg)
        {
            Sender.Tell(new HandshakeResponse(msg.RequestId, msg.DispatchDate));
        }

        /// <summary>
        /// Filters a list of tickets.
        /// </summary>
        /// <param name="richTicketDtos">Tickets.</param>
        /// <param name="ticketFilter">Filtering information.</param>
        /// <returns></returns>
        private static ImmutableList<RichTicketDto> FilterRichTicketDtos(ImmutableList<RichTicketDto> richTicketDtos, TicketFilter ticketFilter)
        {
            if (ticketFilter == null) return richTicketDtos;

            if (ticketFilter.Criterion == QueryCriterion.EventDate)
            {
                return richTicketDtos.Where(t => t.EventDto.Date.Day == ticketFilter.Date.Day).ToImmutableList();
            }
            else
            {
                return richTicketDtos.Where(t => t.PurchaseDate.Day == ticketFilter.Date.Day).ToImmutableList();
            }
        }

        /// <summary>
        /// Sorts a list of tickets.
        /// </summary>
        /// <param name="richTicketDtos">Tickets.</param>
        /// <param name="ticketSorting">Sorting information.</param>
        /// <returns></returns>
        private static ImmutableList<RichTicketDto> SortRichTicketDtos(ImmutableList<RichTicketDto> richTicketDtos, TicketSorting ticketSorting)
        {
            if (ticketSorting == null) return richTicketDtos;

            if (ticketSorting.OrderDirection == OrderDirection.Ascending)
            {
                if (ticketSorting.Criterion == QueryCriterion.PurchaseDate)
                {
                    return richTicketDtos.OrderBy(t => t.PurchaseDate).ToImmutableList();
                }
                else
                {
                    return richTicketDtos.OrderBy(t => t.EventDto.Date).ToImmutableList();
                }
            }
            else
            {
                if (ticketSorting.Criterion == QueryCriterion.PurchaseDate)
                {
                    return richTicketDtos.OrderByDescending(t => t.PurchaseDate).ToImmutableList();
                }
                else
                {
                    return richTicketDtos.OrderByDescending(t => t.EventDto.Date).ToImmutableList();
                }
            }
        }
    }
}
