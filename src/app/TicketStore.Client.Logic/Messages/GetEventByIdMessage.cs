using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Client.Logic.Messages
{
    public class GetEventByIdMessage
    {
        public Guid EventId { get; }

        public GetEventByIdMessage(Guid eventId)
        {
            EventId = eventId;
        }
    }
}
