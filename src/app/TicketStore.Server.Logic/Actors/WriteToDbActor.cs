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
using TicketStore.Shared.Messages;

namespace TicketStore.Server.Logic.Actors
{
    public class WriteToDbActor : ReceiveActor, ILogReceive
    {
        private readonly ILoggingAdapter _logger = Context.GetLogger();
        private readonly IRepositoryWrapper _repoWrapper;

        public WriteToDbActor(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;

            ReceiveAsync<AddUserToDbRequest>(async msg =>
            {
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
                    Sender.Tell(new AddUserToDbResponse(msg.RequestId, null, ex.Message));
                    _logger.Info(ex, "Creating new user failed.");
                }
            });

            ReceiveAsync<AddEventToDbRequest>(async msg =>
            {
                var newEvent = Mapper.EventDtoToEvent(msg.EventDto);

                _repoWrapper.Events.Create(newEvent);

                try
                {
                    await _repoWrapper.SaveAsync().ConfigureAwait(false);
                    Sender.Tell(new AddEventToDbResponse(msg.RequestId, Mapper.EventToEventDto(newEvent)));
                    _logger.Info("Event with id {id} created successfully.", newEvent.Id);
                }
                catch (Exception ex)
                {
                    Sender.Tell(new AddEventToDbResponse(msg.RequestId, null, "Creating new event failed."));
                    _logger.Info(ex, "Creating new event failed.");
                }
            });
        }
    }
}
