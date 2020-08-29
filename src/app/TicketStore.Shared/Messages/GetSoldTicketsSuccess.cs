using System;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Immutable get sold tickets for event success message.
    /// </summary>
    public class GetSoldTicketsSuccess : MessageBase
    {
        /// <summary>
        /// Count of sold tickets.
        /// </summary>
        public int SoldTicketCount { get; }

        /// <summary>
        /// Event id.
        /// </summary>
        public Guid EventId { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="eventId">Event id.</param>
        /// <param name="soldTicketCount">Count of sold tickets.</param>
        public GetSoldTicketsSuccess(Guid requestId, Guid eventId, int soldTicketCount) : base(requestId)
        {
            EventId = eventId;
            SoldTicketCount = soldTicketCount;
        }
    }
}
