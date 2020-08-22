using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Messages
{
    public class GetEventByIdRequest : MessageBase
    {
        public Guid EventId { get; }

        public GetEventByIdRequest(Guid requestId, Guid eventId) : base(requestId)
        {
            EventId = eventId;
        }
    }
}
