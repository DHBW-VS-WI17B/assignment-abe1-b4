using System;

namespace TicketStore.Client.Logic.Messages
{
    /// <summary>
    /// Immutable purchase ticket message.
    /// </summary>
    public class PurchaseTicketsMessage
    {
        /// <summary>
        /// Event id.
        /// </summary>
        public Guid EventId { get; }

        /// <summary>
        /// Ticket count.
        /// </summary>
        public int TicketCount { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="eventId">Event id.</param>
        /// <param name="ticketCount">Ticket count.</param>
        public PurchaseTicketsMessage(Guid eventId, int ticketCount)
        {
            EventId = eventId;
            TicketCount = ticketCount;
        }
    }
}
