using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Server.Logic
{
    public class TicketActor : UntypedActor
    {
        private readonly List<Ticket> _tickets = new List<Ticket>();

        protected override void OnReceive(object message)
        {
            throw new NotImplementedException();
        }
    }
}
