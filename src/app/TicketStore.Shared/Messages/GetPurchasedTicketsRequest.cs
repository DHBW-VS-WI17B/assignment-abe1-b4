using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Enums;

namespace TicketStore.Shared.Messages
{
    public class GetPurchasedTicketsRequest : MessageBase
    {
        public Guid UserId { get; }
        public Order Order { get; }
        public Sort SortBy { get; }

        public GetPurchasedTicketsRequest(Guid requestId, Guid userId, Order order, Sort sortBy) : base(requestId)
        {
            UserId = userId;
            Order = order;
            SortBy = sortBy;
        }
    }
}
