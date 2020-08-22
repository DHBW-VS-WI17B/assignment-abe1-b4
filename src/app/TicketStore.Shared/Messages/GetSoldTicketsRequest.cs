using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Messages
{
    public class GetSoldTicketsRequest : MessageBase
    {
        public Guid EventId { get; }

        public GetSoldTicketsRequest(Guid requestId, Guid eventId) : base(requestId)
        {
            EventId = eventId;
        }
    }
}
