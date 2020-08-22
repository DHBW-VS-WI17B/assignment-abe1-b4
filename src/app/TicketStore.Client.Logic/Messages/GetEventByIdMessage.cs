using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Client.Logic.Messages
{
    /// <summary>
    /// Immutable get event by id message.
    /// </summary>
    public class GetEventByIdMessage
    {
        /// <summary>
        /// Event id.
        /// </summary>
        public Guid EventId { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="eventId">Event id.</param>
        public GetEventByIdMessage(Guid eventId)
        {
            EventId = eventId;
        }
    }
}
