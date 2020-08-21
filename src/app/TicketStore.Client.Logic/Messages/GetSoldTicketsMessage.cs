using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Client.Logic.Messages
{
    public class GetSoldTicketsMessage
    {
        public Guid EventId { get; }

        public GetSoldTicketsMessage(Guid eventId)
        {
            EventId = eventId;
        }
    }
}
