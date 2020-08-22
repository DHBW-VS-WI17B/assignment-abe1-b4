using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Messages;

namespace TicketStore.Server.Logic.Messages.Requests
{
    public class AddTicketToDbRequest : MessageBase
    {
        public Guid EventId { get; }

        public Guid UserId { get; }

        public double RemainingBudget { get; }

        public int TicketCount { get; }

        public AddTicketToDbRequest(Guid requestId, Guid eventId, Guid userId, double remainingBudget, int ticketCount) : base(requestId)
        {
            EventId = eventId;
            UserId = userId;
            RemainingBudget = remainingBudget;
            TicketCount = ticketCount;
        }
    }

}
