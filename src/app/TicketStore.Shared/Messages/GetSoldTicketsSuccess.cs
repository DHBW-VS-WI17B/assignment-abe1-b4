using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Messages
{
    public class GetSoldTicketsSuccess : MessageBase
    {
        public int SoldTicketCount { get; }

        public Guid EventId { get; }

        public GetSoldTicketsSuccess(Guid requestId, Guid eventId, int soldTicketCount) : base(requestId)
        {
            EventId = eventId;
            SoldTicketCount = soldTicketCount;
        }
    }
}
