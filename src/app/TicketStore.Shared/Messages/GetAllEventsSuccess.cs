using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Shared.Messages
{
    public class GetAllEventsSuccess : MessageBase
    {
        public ImmutableList<EventDto> EventDtos { get; }

        public GetAllEventsSuccess(Guid requestId, ImmutableList<EventDto> eventDtos) : base(requestId)
        {
            EventDtos = eventDtos;
        }
    }
}
