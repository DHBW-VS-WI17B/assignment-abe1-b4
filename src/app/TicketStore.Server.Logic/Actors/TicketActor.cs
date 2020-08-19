using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Server.Logic.Actors
{
    public class TicketActor : ReceiveActor
    {
        private readonly ILoggingAdapter _logger = Context.GetLogger();
        private readonly ActorSelection _writeToDbActorRef;

        public TicketActor(ActorSelection writeToDbActorRef)
        {
            _writeToDbActorRef = writeToDbActorRef;
        }
    }
}
