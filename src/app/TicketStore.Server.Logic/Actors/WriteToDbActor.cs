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

namespace TicketStore.Server.Logic.Actors
{
    public class WriteToDbActor : ReceiveActor
    {
        private readonly ILoggingAdapter _logger = Context.GetLogger();
        private readonly IRepositoryWrapper _repoWrapper;

        public WriteToDbActor(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;

            ReceiveAsync<AddEventToDbRequest>(async message =>
            {
                // TODO work in progress
                var newEvent = new Event{};

                _repoWrapper.Events.Create(newEvent);
                await _repoWrapper.SaveAsync().ConfigureAwait(false);
            });
            
        }
    }
}
