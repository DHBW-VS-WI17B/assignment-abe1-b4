using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Server.Logic
{
    public class UserActor : UntypedActor
    {
        private readonly List<User> _users = new List<User>();
        protected override void OnReceive(object message)
        {
            throw new NotImplementedException();
        }
    }
}
