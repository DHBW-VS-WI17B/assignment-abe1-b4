using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Immutable purchase ticket request message.
    /// </summary>
    public class PurchaseTicketsRequest : MessageBase
    {
        /// <summary>
        /// Event id.
        /// </summary>
        public Guid EventId { get; }

        /// <summary>
        /// User id.
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// Remaining budget.
        /// </summary>
        public double RemainingBudget { get; }

        /// <summary>
        /// Count of tickets to be purchased.
        /// </summary>
        public int TicketCount { get;  }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="eventId">Event id.</param>
        /// <param name="userId">User id.</param>
        /// <param name="remainingBudget">Remaining budget.</param>
        /// <param name="ticketCount">Count of tickets to be purchased.</param>
        public PurchaseTicketsRequest(Guid requestId, Guid eventId, Guid userId, double remainingBudget, int ticketCount) : base(requestId)
        {
            EventId = eventId;
            UserId = userId;
            RemainingBudget = remainingBudget;
            TicketCount = ticketCount;
        }
    }
}
