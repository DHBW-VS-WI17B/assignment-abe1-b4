using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Messages;

namespace TicketStore.Server.Logic
{
    public class RegisterUserActor : ReceiveActor
    {
        private readonly IActorRef _userActorRef;

        public RegisterUserActor(IActorRef userActorRef)
        {
            _userActorRef = userActorRef;

            ReceiveAsync<RegisterUserRequest>(async msg =>
            {
                var getUserByUserNameResponse = await _userActorRef.Ask<GetUserByUserNameResponse>(new GetUserByUserNameRequest(msg?.UserName)).ConfigureAwait(false);

                if (!getUserByUserNameResponse.IsSuccess)
                {
                    Sender.Tell(new RegisterUserResponse(getUserByUserNameResponse?.ErrorMessage));
                    return;
                }


            });
        }
    } 
}
