using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using TicketStore.Server.Logic.DataAccess.Contracts;
using TicketStore.Server.Logic.Messages;
using TicketStore.Server.Logic.Messages.Requests;
using TicketStore.Server.Logic.Messages.Responses;
using TicketStore.Server.Logic.Util;
using TicketStore.Shared.Messages;

namespace TicketStore.Server.Logic.Actors
{
    public class EventActor : ReceiveActor, ILogReceive
    {
        private readonly ILoggingAdapter _logger = Context.GetLogger();
        private readonly ActorSelection _writeToDbActorRef;
        private readonly IRepositoryWrapper _repo;

        public EventActor(IRepositoryWrapper repoWrapper, ActorSelection writeToDbActorRef)
        {
            _repo = repoWrapper;
            _writeToDbActorRef = writeToDbActorRef;

            ReceiveAsync<CreateEventRequest>(async msg =>
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
            });

            Receive<GetSoldTicketsRequest>(msg =>
            {
                if(_repo.Events.FindByCondition(e => e.Id == msg.EventId).Any())
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
            });

            Receive<GetAllEventsRequest>(msg =>
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
                } else
                {
                    _logger.Info("Found {count} events in the databse.", eventDtos.Count);
                    Sender.Tell(new GetAllEventsSuccess(msg.RequestId, eventDtos));
                }
            });

            Receive<GetEventByIdRequest>(msg =>
            {
                var eventWithId = _repo.Events.FindByCondition(e => e.Id == msg.EventId).FirstOrDefault();

                if(eventWithId == null)
                {
                    _logger.Warning("Event with id {eventId} does not exist!", msg.EventId);
                    Sender.Tell(new ErrorMessage(msg.RequestId, $"Event with id {msg.EventId} does not exist!"));
                }
                else
                {
                    _logger.Info("Found event with id {id}", msg.EventId);
                    Sender.Tell(new GetEventByIdSuccess(msg.RequestId, Mapper.EventToEventDto(eventWithId)));
                }
            });

            ReceiveAsync<PurchaseTicketRequest>(async msg =>
            {
                var sender = Sender;
                var response = await _writeToDbActorRef.Ask<AddTicketToDbResponse>(new AddTicketToDbRequest(msg.RequestId, msg.EventId, msg.UserId, msg.RemainingBudget, msg.TicketCount)).ConfigureAwait(false);

                if (response.Successful)
                {
                    _logger.Info("Purchased ticker for event with id {eventId} successfully.", msg.EventId);
                    sender.Tell(new PurchaseTicketSuccess(msg.RequestId, response.TicketDto, response.Costs));
                }
                else
                {
                    _logger.Info("Purchase ticket request was not successfull. Reason: {reason}", response.ErrorMessage);
                    sender.Tell(new ErrorMessage(msg.RequestId, response.ErrorMessage));
                }
            });
        }
    }
}
