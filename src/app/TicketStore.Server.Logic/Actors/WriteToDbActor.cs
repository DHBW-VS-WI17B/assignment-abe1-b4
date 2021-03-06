﻿using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using TicketStore.Server.Logic.DataAccess.Contracts;
using TicketStore.Server.Logic.DataAccess.Entities;
using TicketStore.Server.Logic.Messages.Requests;
using TicketStore.Server.Logic.Messages.Responses;
using TicketStore.Server.Logic.Util;
using TicketStore.Shared.Models;

namespace TicketStore.Server.Logic.Actors
{
    /// <summary>
    /// Actor with write access to the database. Instantiated as singleton to avoid data consistency issues.
    /// </summary>
    public class WriteToDbActor : ReceiveActor, ILogReceive
    {
        private readonly ILoggingAdapter _logger = Context.GetLogger();
        private readonly IRepositoryWrapper _repo;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repoWrapper">Wrapper around all data repositories.</param>
        public WriteToDbActor(IRepositoryWrapper repoWrapper)
        {
            _repo = repoWrapper;

            // register message handlers
            ReceiveAsync<AddUserToDbRequest>(ProcessMessageAsync);
            ReceiveAsync<AddEventToDbRequest>(ProcessMessageAsync);
            ReceiveAsync<AddTicketsToDbRequest>(ProcessMessageAsync);
        }

        /// <summary>
        /// Processes a add user to db request message.
        /// </summary>
        /// <param name="msg">Immutable add user to db request message.</param>
        /// <returns>Task.</returns>
        private async Task ProcessMessageAsync(AddUserToDbRequest msg)
        {
            var newUser = Mapper.UserDtoToUser(msg.UserDto);

            _repo.Users.Create(newUser);

            try
            {
                await _repo.SaveAsync().ConfigureAwait(false);
                Sender.Tell(new AddUserToDbResponse(msg.RequestId, Mapper.UserToUserDto(newUser)));
                _logger.Debug("User with id {id} created successfully.", newUser.Id);
            }
            catch (Exception ex)
            {
                Sender.Tell(new AddUserToDbResponse(msg.RequestId, null, ex.Message));
                _logger.Debug(ex, "Creating new user failed.");
            }
        }

        /// <summary>
        /// Processes a add event to db request message.
        /// </summary>
        /// <param name="msg">Immutable add event to db request message.</param>
        /// <returns>Task.</returns>
        private async Task ProcessMessageAsync(AddEventToDbRequest msg)
        {
            var newEvent = Mapper.EventDtoToEvent(msg.EventDto);

            _repo.Events.Create(newEvent);

            try
            {
                await _repo.SaveAsync().ConfigureAwait(false);
                Sender.Tell(new AddEventToDbResponse(msg.RequestId, Mapper.EventToEventDto(newEvent)));
                _logger.Debug("Event with id {id} created successfully.", newEvent.Id);
            }
            catch (Exception ex)
            {
                Sender.Tell(new AddEventToDbResponse(msg.RequestId, null, "Creating new event failed."));
                _logger.Debug(ex, "Creating new event failed.");
            }
        }

        /// <summary>
        /// Process a add tickets to db request message. Validates the purchase request and creates the tickets in the database.
        /// </summary>
        /// <param name="msg">Immutable add tickets to db request message.</param>
        /// <returns></returns>
        private async Task ProcessMessageAsync(AddTicketsToDbRequest msg)
        {
            var targetEvent = _repo.Events.FindByCondition(e => e.Id == msg.EventId).FirstOrDefault();

            if (targetEvent == null)
            {
                _logger.Warning("Event with id {eventId} does not exist!", msg.EventId);
                Sender.Tell(new AddTicketsToDbResponse(msg.RequestId, null, $"Event with id {msg.EventId} does not exist!"));
                return;
            }

            if (!_repo.Users.FindByCondition(u => u.Id == msg.UserId).Any())
            {
                _logger.Warning("User with id {eventId} does not exist!", msg.UserId);
                Sender.Tell(new AddTicketsToDbResponse(msg.RequestId, null, $"User with id {msg.UserId} does not exist!"));
                return;
            }

            if (DateTime.UtcNow > targetEvent.SaleEndDate || DateTime.UtcNow < targetEvent.SaleStartDate)
            {
                _logger.Warning("There is no active sale for event with id {id}!", msg.EventId);
                Sender.Tell(new AddTicketsToDbResponse(msg.RequestId, null, $"There is no active sale for event with id {msg.EventId}!"));
                return;
            }

            var soldTickets = _repo.Tickets.FindByCondition(t => t.EventId == msg.EventId).ToImmutableList();
            if (soldTickets.Count + msg.TicketCount > targetEvent.MaxTicketCount)
            {
                _logger.Warning("Can not sell ticket for event with id {id}. Not enough tickets left!", msg.EventId);
                Sender.Tell(new AddTicketsToDbResponse(msg.RequestId, null, $"Can not sell ticket for event with id {msg.EventId}. Not enough tickets left!"));
                return;
            }

            var remainingBudget = GetRemainingBudget(msg.UserId, targetEvent.Date.Year);
            if (msg.TicketCount * targetEvent.PricePerTicket > remainingBudget)
            {
                _logger.Warning("Can not sell ticket(s) for event with id {id}. Budget is {missingMoney} money units too small.", msg.EventId, (msg.TicketCount * targetEvent.PricePerTicket) - remainingBudget);
                Sender.Tell(new AddTicketsToDbResponse(msg.RequestId, null, $"Can not sell ticket(s) for event with id {msg.EventId}. Budget is {(msg.TicketCount * targetEvent.PricePerTicket) - remainingBudget} money units too small."));
                return;
            }

            var ticketsSoldToUser = soldTickets.Where(t => t.UserId == msg.UserId).ToImmutableList();
            if (ticketsSoldToUser.Count + msg.TicketCount > targetEvent.MaxTicketsPerUser)
            {
                _logger.Warning("Can not sell ticket(s) for event with id {id}. Not enough tickets for user with {id} left!", msg.EventId, msg.UserId);
                Sender.Tell(new AddTicketsToDbResponse(msg.RequestId, null, $"Can not sell ticket(s) for event with id {msg.EventId}. Not enough tickets for user with {msg.UserId} left!"));
                return;
            }

            List<TicketDto> newTickets = new List<TicketDto>();
            for (int i = 0; i < msg.TicketCount; i++)
            {
                var ticket = new Ticket { EventId = msg.EventId, PurchaseDate = DateTime.UtcNow, UserId = msg.UserId };
                _repo.Tickets.Create(ticket);
                newTickets.Add(Mapper.TicketToTicketDto(ticket));
            }

            try
            {
                await _repo.SaveAsync().ConfigureAwait(false);
                Sender.Tell(new AddTicketsToDbResponse(msg.RequestId, newTickets.ToImmutableList()));
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Saving tickets failed!");
                Sender.Tell(new AddTicketsToDbResponse(msg.RequestId, null, "Creating new ticket(s) failed on database level."));
            }
        }

        /// <summary>
        /// Gets the remaining budget of a user for a year.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="year">Year.</param>
        /// <returns>Remaining budget for given year.</returns>
        private double GetRemainingBudget(Guid userId, int year)
        {
            double spentOnEvents = 0;

            if (_repo.Tickets.FindByCondition(t => t.UserId == userId).Any())
            {
                var eventIds = _repo.Tickets.FindByCondition(t => t.UserId == userId).Select(ticket => ticket.EventId).ToList();
                var events = eventIds.Select(eventId => _repo.Events.FindByCondition(e => e.Id == eventId).FirstOrDefault()).ToList();
                spentOnEvents = events.Where(e => e.Date.Year == year).Sum(x => x.PricePerTicket);
            }
            var budget = _repo.Users.FindByCondition(u => u.Id == userId).FirstOrDefault().YearlyBudget;

            return budget - spentOnEvents;
        }
    }
}
