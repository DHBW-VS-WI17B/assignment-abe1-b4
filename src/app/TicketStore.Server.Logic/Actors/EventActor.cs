using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Server.Logic.Actors
{
    public class EventActor : ReceiveActor
    {
        private readonly ILoggingAdapter _logger = Context.GetLogger();

        public EventActor()
        {
            Receive<string>(message =>
            {
                _logger.Info("Received: {0}", message);
            });
        }
    }
}
