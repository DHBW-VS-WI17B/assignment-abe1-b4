using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Logic.Messages.Requests;
using TicketStore.Server.Logic.Messages.Responses;
using TicketStore.Shared.Messages;

namespace TicketStore.Server.Logic.Actors
{
    public class UserActor : ReceiveActor, ILogReceive
    {
        private readonly ILoggingAdapter _logger = Context.GetLogger();
        private readonly ActorSelection _writeToDbActorRef;

        public UserActor(ActorSelection writeToDbActorRef)
        {
            _writeToDbActorRef = writeToDbActorRef;

            ReceiveAsync<CreateUserRequest>(async msg =>
            {
                // akka is not able to remember the sender after an async operation.
                var sender = Sender;

                var addUserToDbResponse = await _writeToDbActorRef.Ask<AddUserToDbResponse>(new AddUserToDbRequest(msg.RequestId, msg.UserDto)).ConfigureAwait(false);

                if (addUserToDbResponse.Successful)
                {
                    _logger.Info("Adding user to db succeded. New user id: {userId}", addUserToDbResponse.UserDto.Id);
                    sender.Tell(new CreateUserSuccess(msg.RequestId, addUserToDbResponse.UserDto));
                } 
                else
                {
                    _logger.Info("Adding user to db failed. Reason: {err}", addUserToDbResponse.ErrorMessage);
                    sender.Tell(new ErrorMessage(msg.RequestId, addUserToDbResponse.ErrorMessage));
                }
            });
        }
    }
}
