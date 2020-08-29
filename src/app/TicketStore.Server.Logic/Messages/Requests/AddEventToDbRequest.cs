using System;
using TicketStore.Shared.Messages;
using TicketStore.Shared.Models;

namespace TicketStore.Server.Logic.Messages.Requests
{
    /// <summary>
    /// Immutable add event to database request message.
    /// </summary>
    public class AddEventToDbRequest : MessageBase
    {
        /// <summary>
        /// The event to be added.
        /// </summary>
        public EventDto EventDto { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">The id of this request.</param>
        /// <param name="eventDto">The event to be added.</param>
        public AddEventToDbRequest(Guid requestId, EventDto eventDto) : base(requestId)
        {
            EventDto = eventDto;
        }
    }
}
