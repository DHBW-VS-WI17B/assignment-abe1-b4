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
        /// Count of tickets to be purchased.
        /// </summary>
        public int TicketCount { get;  }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="eventId">Event id.</param>
        /// <param name="userId">User id.</param>
        /// <param name="ticketCount">Count of tickets to be purchased.</param>
        public PurchaseTicketsRequest(Guid requestId, Guid eventId, Guid userId, int ticketCount) : base(requestId)
        {
            EventId = eventId;
            UserId = userId;
            TicketCount = ticketCount;
        }
    }
}
