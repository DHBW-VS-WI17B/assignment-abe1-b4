using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Logic.DataAccess;
using TicketStore.Server.Logic.DataAccess.Contracts;
using TicketStore.Server.Logic.DataAccess.Entities;
using TicketStore.Server.Logic.Messages;
using TicketStore.Server.Logic.Messages.Requests;
using TicketStore.Server.Logic.Messages.Responses;
using TicketStore.Server.Logic.Util;

namespace TicketStore.Server.Logic.Actors
{
    public class WriteToDbActor : ReceiveActor
    {
        private readonly ILoggingAdapter _logger = Context.GetLogger();
        private readonly IRepositoryWrapper _repoWrapper;

        public WriteToDbActor(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;

            Receive<AddUserToDbRequest>(async msg =>
            {
                _logger.Info("Received message: {msg}", msg);

                var newUser = Mapper.UserDtoToUser(msg.UserDto);

                _repoWrapper.Users.Create(newUser);

                try
                {
                    await _repoWrapper.SaveAsync().ConfigureAwait(false);
                    Sender.Tell(new AddUserToDbResponse(msg.RequestId, Mapper.UserToUserDto(newUser)));
                    _logger.Info("User with id {id} created successfully.", newUser.Id);
                }
                catch (Exception ex)
                {
                    Sender.Tell(new AddUserToDbResponse(msg.RequestId, ex.Message));
                    _logger.Info("Creating new user failed. Reason: {reason}", ex.Message);
                }
            });
        }
    }
}
