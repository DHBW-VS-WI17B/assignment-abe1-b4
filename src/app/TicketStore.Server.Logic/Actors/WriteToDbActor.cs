using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Logic.DataAccess;
using TicketStore.Server.Logic.DataAccess.Entities;
using TicketStore.Server.Logic.Messages;
using TicketStore.Server.Logic.Messages.Requests;

namespace TicketStore.Server.Logic.Actors
{
    public class WriteToDbActor : ReceiveActor
    {
        private readonly ILoggingAdapter _logger = Context.GetLogger();

        public WriteToDbActor()
        {
            ReceiveAsync<AddEventToDbRequest>(async message =>
            {
                using var ctx = new RepositoryContext();

                // TODO work in progress
                var newEvent = new Event{};

                ctx.Events.Add(newEvent);
                await ctx.SaveChangesAsync().ConfigureAwait(false);
            });
        }
    }
}
