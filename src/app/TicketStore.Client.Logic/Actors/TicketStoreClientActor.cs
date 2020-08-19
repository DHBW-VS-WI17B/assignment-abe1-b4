using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Client.Logic.Actors
{
    public class TicketStoreClientActor : ReceiveActor
    {
        private readonly ActorSelection _remoteEventActorRef;
        private readonly ActorSelection _remoteUserActorRef;
        private readonly ILoggingAdapter _logger = Context.GetLogger();

        // TODO this client has some state (yearly budget, username)

        public TicketStoreClientActor(ActorSelection remoteEventActorRef, ActorSelection remoteUserActorRef)
        {
            _remoteEventActorRef = remoteEventActorRef;
            _remoteUserActorRef = remoteUserActorRef;

            Receive<string>(message =>
            {
                _logger.Info("Received: {message}", message);
                _remoteEventActorRef.Tell(message);
            });
        }
    }
}
