using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Immutable create event request message.
    /// </summary>
    public class CreateEventRequest : MessageBase
    {
        /// <summary>
        /// Event to be created.
        /// </summary>
        public EventDto EventDto { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="eventDto">Event data transfer object.</param>
        public CreateEventRequest(Guid requestId, EventDto eventDto) : base (requestId)
        {
            EventDto = eventDto;
        }
    }
}
