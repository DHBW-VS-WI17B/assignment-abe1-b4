using System;

namespace TicketStore.Client.Logic.Messages
{
    /// <summary>
    /// Immutable get sold tickets message.
    /// </summary>
    public class GetSoldTicketsMessage
    {
        /// <summary>
        /// Event id.
        /// </summary>
        public Guid EventId { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="eventId">Event id.</param>
        public GetSoldTicketsMessage(Guid eventId)
        {
            EventId = eventId;
        }
    }
}
