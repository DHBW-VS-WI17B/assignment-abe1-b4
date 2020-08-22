using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Messages
{
    public class GetPurchasedTicketsRequest : MessageBase
    {
        public Guid UserId { get; }

        public GetPurchasedTicketsRequest(Guid requestId, Guid userId) : base(requestId)
        {
            UserId = userId;
        }
    }
}
