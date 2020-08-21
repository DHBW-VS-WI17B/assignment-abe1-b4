using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Logic.Messages.Requests;
using TicketStore.Server.Logic.Messages.Responses;
using TicketStore.Shared.Requests;
using TicketStore.Shared.Responses;

namespace TicketStore.Server.Logic.Actors
{
    public class UserActor : ReceiveActor
    {
        private readonly ILoggingAdapter _logger = Context.GetLogger();
        private readonly ActorSelection _writeToDbActorRef;

        public UserActor(ActorSelection writeToDbActorRef)
        {
            _writeToDbActorRef = writeToDbActorRef;

            Receive<CreateUserRequest>(async msg =>
            {
                _logger.Info("Received message: {msg}", msg);

                var addUserToDbResponse = await _writeToDbActorRef.Ask<AddUserToDbResponse>(new AddUserToDbRequest(msg.UserDto)).ConfigureAwait(false);

                if (addUserToDbResponse.Successful)
                {
                    _logger.Info("Adding user to db succeded. New user id: {userId}", addUserToDbResponse.UserDto.Id);
                    Sender.Tell(new CreateUserResponse(msg.RequestId, addUserToDbResponse.UserDto));
                } 
                else
                {
                    _logger.Info("Adding user to db failed. Reason: {err}", addUserToDbResponse.ErrorMessage);
                    Sender.Tell(new CreateUserResponse(msg.RequestId, addUserToDbResponse.ErrorMessage));
                }
            });
        }
    }
}
