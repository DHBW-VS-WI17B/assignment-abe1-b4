using System;
using TicketStore.Shared.Models;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Immutable get event by id success message.
    /// </summary>
    public class GetEventByIdSuccess : MessageBase
    {
        /// <summary>
        /// Event data transfer object.
        /// </summary>
        public EventDto EventDto { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="eventDto">Event data transfer object.</param>
        public GetEventByIdSuccess(Guid requestId, EventDto eventDto) : base(requestId)
        {
            EventDto = eventDto;
        }
    }
}
