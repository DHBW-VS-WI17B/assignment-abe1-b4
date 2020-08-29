using System;
using TicketStore.Shared.Models;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Immutable create event success message.
    /// </summary>
    public class CreateEventSuccess : MessageBase
    {
        /// <summary>
        /// Created event.
        /// </summary>
        public EventDto EventDto { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="eventDto">Created event data transfer object.</param>
        public CreateEventSuccess(Guid requestId, EventDto eventDto) : base(requestId)
        {
            EventDto = eventDto;
        }
    }
}
