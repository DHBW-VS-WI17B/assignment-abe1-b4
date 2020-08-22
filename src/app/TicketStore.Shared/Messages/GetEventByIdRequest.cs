using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Immutable get event by id request message.
    /// </summary>
    public class GetEventByIdRequest : MessageBase
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
        public GetEventByIdRequest(Guid requestId, Guid eventId) : base(requestId)
        {
            EventId = eventId;
        }
    }
}
