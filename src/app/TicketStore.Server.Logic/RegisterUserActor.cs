using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Messages;

namespace TicketStore.Server.Logic
{
    public class RegisterUserActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case RegisterUserRequest msg:
                    // check if already registered
                    // register
                    // send back response
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    } 
}
