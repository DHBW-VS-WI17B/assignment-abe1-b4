using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Shared.Messages
{
    public class CreateEventRequest : MessageBase
    {
        public EventDto EventDto { get; }

        public CreateEventRequest(Guid requestId, EventDto eventDto) : base (requestId)
        {
            EventDto = eventDto;
        }
    }
}
