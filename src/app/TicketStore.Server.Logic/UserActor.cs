using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Messages;
using TicketStore.Shared.Models;

namespace TicketStore.Server.Logic
{
    public class UserActor : UntypedActor
    {
        private readonly List<User> _users = new List<User>();
        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case GetUserByUserNameRequest msg:
                    if (string.IsNullOrWhiteSpace(msg?.UserName))
                    {
                        Sender.Tell(new GetUserByUserNameResponse($"{nameof(msg.UserName)} is invalid."));
                        break;
                    }

                    var user = GetUserByUserName(msg?.UserName);

                    if (user == null)
                    {
                        Sender.Tell(new GetUserByUserNameResponse($"User with username {msg?.UserName} not found."));
                        break;
                    }

                    Sender.Tell(new GetUserByUserNameResponse(user));
                    break;
                default:
                    throw new InvalidOperationException("Message type invalid");
            }
        }

        private User GetUserByUserName(string userName)
        {
            return _users.Find(user => user.UserName == userName);
        }
    }
}
