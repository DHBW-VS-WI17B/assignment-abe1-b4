using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Logic.DataAccess;
using TicketStore.Server.Logic.DataAccess.Entities;
using TicketStore.Server.Logic.Messages;

namespace TicketStore.Server.Logic.Actors
{
    public class WriteToDbActor : ReceiveActor
    {
        public WriteToDbActor()
        {
            ReceiveAsync<WriteEventToDb>(async message =>
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
