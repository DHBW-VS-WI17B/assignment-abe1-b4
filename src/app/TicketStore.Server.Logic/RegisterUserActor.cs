using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Server.Logic
{
    public class RegisterUserActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case RegisterUserMessage msg:
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    } 
}
