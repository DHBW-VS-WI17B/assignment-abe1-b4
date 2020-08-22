using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Client.Logic.Messages
{
    public class PurchaseTicketMessage
    {
        public Guid EventId { get; }

        public int TicketCount { get; }

        public PurchaseTicketMessage(Guid eventId, int ticketCount)
        {
            EventId = eventId;
            TicketCount = ticketCount;
        }
    }
}
