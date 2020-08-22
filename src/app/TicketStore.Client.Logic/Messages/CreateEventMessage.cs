using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Client.Logic.Messages
{
    /// <summary>
    /// Immutable create event message.
    /// </summary>
    public class CreateEventMessage
    {
        /// <summary>
        /// Event to be created.
        /// </summary>
        public EventDto EventDto { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="eventDto">Event to be created.</param>
        public CreateEventMessage(EventDto eventDto)
        {
            EventDto = eventDto;
        }
    }
}
