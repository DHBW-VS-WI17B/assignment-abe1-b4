using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Server.Logic.Actors
{
    public class UserActor : ReceiveActor
    {
        private readonly ILoggingAdapter _logger = Context.GetLogger();
        private readonly ActorSelection _writeToDbActorRef;

        public UserActor(ActorSelection writeToDbActorRef)
        {
            _writeToDbActorRef = writeToDbActorRef;
        }
    }
}
