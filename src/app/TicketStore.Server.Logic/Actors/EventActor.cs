using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketStore.Server.Logic.DataAccess.Contracts;
using TicketStore.Server.Logic.Messages;
using TicketStore.Server.Logic.Messages.Requests;
using TicketStore.Server.Logic.Messages.Responses;
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
        }
    }
}
