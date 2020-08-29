using System;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Immutable get sold tickets for event request message.
    /// </summary>
    public class GetSoldTicketsRequest : MessageBase
    {
        /// <summary>
        /// Event id.
        /// </summary>
        public Guid EventId { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="eventId">Event id.</param>
        public GetSoldTicketsRequest(Guid requestId, Guid eventId) : base(requestId)
        {
            EventId = eventId;
        }
    }
}
