using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Server.Logic
{
    public class HappeningActor : UntypedActor
    {
        private readonly List<Happening> _happenings = new List<Happening>();

        protected override void OnReceive(object message)
        {
            throw new NotImplementedException();
        }
    }
}
