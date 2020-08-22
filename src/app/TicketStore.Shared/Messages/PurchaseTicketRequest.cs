using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Messages
{
    public class PurchaseTicketRequest : MessageBase
    {
        public Guid EventId { get; }

        public Guid UserId { get; }

        public double RemainingBudget { get; }

        public int TicketCount { get;  }

        public PurchaseTicketRequest(Guid requestId, Guid eventId, Guid userId, double remainingBudget, int ticketCount) : base(requestId)
        {
            EventId = eventId;
            UserId = userId;
            RemainingBudget = remainingBudget;
            TicketCount = ticketCount;
        }
    }
}
