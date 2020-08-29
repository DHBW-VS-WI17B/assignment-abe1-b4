using System;
using TicketStore.Shared.Models;

namespace TicketStore.Server.Logic.Messages.Responses
{
    /// <summary>
    /// Immutable add event to database response message.
    /// </summary>
    public class AddEventToDbResponse : ResponseBase
    {
        /// <summary>
        /// Added event.
        /// </summary>
        public EventDto EventDto { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="eventDto">Event id.</param>
        /// <param name="errorMessage">Error message.</param>
        public AddEventToDbResponse(Guid requestId, EventDto eventDto, string errorMessage = null) : base(requestId, errorMessage)
        {
            EventDto = eventDto;
        }
    }
}
