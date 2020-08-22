using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
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
        private readonly IRepositoryWrapper _repo;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repoWrapper">Wrapper around all data repositories.</param>
        /// <param name="writeToDbActorRef">Reference to an actor with write access to the database.</param>
        public UserActor(IRepositoryWrapper repoWrapper, ActorSelection writeToDbActorRef)
        {
            _repo = repoWrapper;
            _writeToDbActorRef = writeToDbActorRef;

            ReceiveAsync<CreateUserRequest>(async msg =>
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
            });

            Receive<GetPurchasedTicketsRequest>(msg =>
            {
                var purchasedTickets = _repo.Tickets.FindByCondition(t => t.UserId == msg.UserId).ToImmutableList();

                if (purchasedTickets.Count == 0)
                {
                    _logger.Info("There are no ticket purchases for user with id {userId}", msg.UserId);
                    Sender.Tell(new ErrorMessage(msg.RequestId, $"There are no ticket purchases for user with id {msg.UserId}"));
                    return;
                }

                var enrichedPurchasedTickets = purchasedTickets.Select(t => new RichTicketDto(t.Id, t.PurchaseDate, t.UserId, Mapper.EventToEventDto(_repo.Events.FindByCondition(e => e.Id == t.EventId).FirstOrDefault()))).ToImmutableList();

                IImmutableList<RichTicketDto> sortedAndOrderedPurchasedTickets;
                if (msg.Order == Order.Ascending)
                {
                    if (msg.SortBy == Sort.PurchaseDate)
                    {
                        sortedAndOrderedPurchasedTickets = enrichedPurchasedTickets.OrderBy(t => t.PurchaseDate).ToImmutableList();
                    }
                    else
                    {
                        sortedAndOrderedPurchasedTickets = enrichedPurchasedTickets.OrderBy(t => t.EventDto.Date).ToImmutableList();
                    }
                }
                else
                {
                    if (msg.SortBy == Sort.PurchaseDate)
                    {
                        sortedAndOrderedPurchasedTickets = enrichedPurchasedTickets.OrderByDescending(t => t.PurchaseDate).ToImmutableList();
                    }
                    else
                    {
                        sortedAndOrderedPurchasedTickets = enrichedPurchasedTickets.OrderByDescending(t => t.EventDto.Date).ToImmutableList();
                    }
                }

                _logger.Info("Found and ordered {count} tickets for user with id {userid}.", sortedAndOrderedPurchasedTickets.Count, msg.UserId);
                Sender.Tell(new GetPurchasedTicketsSuccess(msg.RequestId, sortedAndOrderedPurchasedTickets));
            });
        }
    }
}
