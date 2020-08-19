using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Client.Logic.Actors
{
    public class TicketStoreClientActor : ReceiveActor
    {
        private readonly ActorSelection _eventActor;
        private readonly ActorSelection _userActor;
        private readonly ILoggingAdapter _logger = Context.GetLogger();

        // TODO this client has some state (yearly budget, username)

        public TicketStoreClientActor(ActorSelection eventActor, ActorSelection userActor)
        {
            _eventActor = eventActor;
            _userActor = userActor;

            Receive<string>(message =>
            {
                _logger.Info("Received: {message}", message);
                _eventActor.Tell(message);
            });
        }
    }
}
