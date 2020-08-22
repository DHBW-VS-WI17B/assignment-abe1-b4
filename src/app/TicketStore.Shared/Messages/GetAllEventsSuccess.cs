using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Immutable get all events success message.
    /// </summary>
    public class GetAllEventsSuccess : MessageBase
    {
        /// <summary>
        /// Immutable list of all available events.
        /// </summary>
        public ImmutableList<EventDto> EventDtos { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="eventDtos">Immutable list of all available events.</param>
        public GetAllEventsSuccess(Guid requestId, ImmutableList<EventDto> eventDtos) : base(requestId)
        {
            EventDtos = eventDtos;
        }
    }
}
