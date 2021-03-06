﻿using Akka.Actor;
using Akka.Event;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using TicketStore.Server.Logic.DataAccess.Contracts;
using TicketStore.Server.Logic.Messages.Requests;
using TicketStore.Server.Logic.Messages.Responses;
using TicketStore.Server.Logic.Util;
using TicketStore.Shared.Messages;

namespace TicketStore.Server.Logic.Actors
{
    /// <summary>
    /// Event actor. Handles all event related requests. Has no write access to the database. Can be instantiated multiple times.
    /// </summary>
    public class EventActor : ReceiveActor, ILogReceive
    {
        private readonly ILoggingAdapter _logger = Context.GetLogger();
        private readonly ActorSelection _writeToDbActorRef;
        private readonly IReadonlyRepositoryWrapper _repo;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repoWrapper">Readonly wrapper around all data repositories.</param>
        /// <param name="writeToDbActorRef">Reference to an actor with write access to the database.</param>
        public EventActor(IReadonlyRepositoryWrapper repoWrapper, ActorSelection writeToDbActorRef)
        {
            _repo = repoWrapper;
            _writeToDbActorRef = writeToDbActorRef;

            // register message handlers
            ReceiveAsync<CreateEventRequest>(ProcessMessageAsync);
            Receive<GetSoldTicketsRequest>(ProcessMessage);
            Receive<GetAllEventsRequest>(ProcessMessage);
            Receive<GetEventByIdRequest>(ProcessMessage);
            ReceiveAsync<PurchaseTicketsRequest>(ProcessMessageAsync);
            Receive<HandshakeRequest>(ProcessMessage);
        }

        /// <summary>
        /// Processes a create event request message. Forwards the message to the write to db actor.
        /// </summary>
        /// <param name="msg">Immutable create event request messgae.</param>
        /// <returns>Task.</returns>
        private async Task ProcessMessageAsync(CreateEventRequest msg)
        {
            var sender = Sender;
            var result = await _writeToDbActorRef.Ask<AddEventToDbResponse>(new AddEventToDbRequest(msg.RequestId, msg.EventDto)).ConfigureAwait(false);

            if (result.Successful)
            {
                _logger.Info("Adding event to db succeded. New event id: {eventId}", result.EventDto.Id);
                sender.Tell(new CreateEventSuccess(msg.RequestId, result.EventDto));
            }
            else
            {
                _logger.Info("Adding event to db failed. Reason: {err}", result.ErrorMessage);
                sender.Tell(new ErrorMessage(msg.RequestId, result.ErrorMessage));
            }
        }

        /// <summary>
        /// Processes a get sold tickets request message.
        /// </summary>
        /// <param name="msg">Immutable get sold tickets request message.</param>
        private void ProcessMessage(GetSoldTicketsRequest msg)
        {
            if (_repo.Events.FindByCondition(e => e.Id == msg.EventId).Any())
            {
                var tickets = _repo.Tickets.FindByCondition(t => t.EventId == msg.EventId).ToList();
                _logger.Info("Event id {id} sold {count} ticket(s) so far.", msg.EventId, tickets.Count);
                Sender.Tell(new GetSoldTicketsSuccess(msg.RequestId, msg.EventId, tickets.Count));
            }
            else
            {
                _logger.Info("Event id {id} does not exist.", msg.EventId);
                Sender.Tell(new ErrorMessage(msg.RequestId, $"Event id {msg.EventId} does not exist."));
            }
        }

        /// <summary>
        /// Processes a get all events request message.
        /// </summary>
        /// <param name="msg">Immutable get all events request message.</param>
        private void ProcessMessage(GetAllEventsRequest msg)
        {
            var eventDtos = _repo.Events
                    .FindAll()
                    .ToList()
                    .Select(x => Mapper.EventToEventDto(x))
                    .ToImmutableList();

            if (eventDtos.Count == 0)
            {
                _logger.Info("There are no events in the database.");
                Sender.Tell(new ErrorMessage(msg.RequestId, "There are no events in the datebase."));
            }
            else
            {
                _logger.Info("Found {count} events in the database.", eventDtos.Count);
                Sender.Tell(new GetAllEventsSuccess(msg.RequestId, eventDtos));
            }
        }

        /// <summary>
        /// Processes a get event by id request message.
        /// </summary>
        /// <param name="msg">Immutable get event by id request message.</param>
        private void ProcessMessage(GetEventByIdRequest msg)
        {
            var eventWithId = _repo.Events.FindByCondition(e => e.Id == msg.EventId).FirstOrDefault();

            if (eventWithId == null)
            {
                _logger.Warning("Event with id {eventId} does not exist!", msg.EventId);
                Sender.Tell(new ErrorMessage(msg.RequestId, $"Event with id {msg.EventId} does not exist!"));
            }
            else
            {
                _logger.Info("Found event with id {id}", msg.EventId);
                Sender.Tell(new GetEventByIdSuccess(msg.RequestId, Mapper.EventToEventDto(eventWithId)));
            }
        }

        /// <summary>
        /// Processes a purchase tickets request message. Forwards the request to the db actor with write access.
        /// </summary>
        /// <param name="msg">Immutable purchase tickets request.</param>
        /// <returns></returns>
        private async Task ProcessMessageAsync(PurchaseTicketsRequest msg)
        {
            var sender = Sender;

            var response = await _writeToDbActorRef.Ask<AddTicketsToDbResponse>(new AddTicketsToDbRequest(msg.RequestId, msg.EventId, msg.UserId, msg.TicketCount)).ConfigureAwait(false);

            if (response.Successful)
            {
                _logger.Info("Purchased ticker for event with id {eventId} successfully.", msg.EventId);
                sender.Tell(new PurchaseTicketsSuccess(msg.RequestId, response.TicketDtos));
            }
            else
            {
                _logger.Info("Purchase ticket request was not successfull. Reason: {reason}", response.ErrorMessage);
                sender.Tell(new ErrorMessage(msg.RequestId, response.ErrorMessage));
            }
        }

        /// <summary>
        /// Processes a handshake request. Sends a response.
        /// </summary>
        /// <param name="msg">Immutable handshake request.</param>
        private void ProcessMessage(HandshakeRequest msg)
        {
            Sender.Tell(new HandshakeResponse(msg.RequestId, msg.DispatchDate));
        }
    }
}
