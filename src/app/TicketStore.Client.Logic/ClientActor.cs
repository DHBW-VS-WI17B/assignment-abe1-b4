using Akka.Actor;
using System;

namespace TicketStore.Client.Logic
{
    public class ClientActor : UntypedActor
    {
        private readonly double _budget;
        protected override void OnReceive(object message)
        {
            throw new NotImplementedException();
        }
    }
}
