using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Shared.Messages
{
    public class GetEventByIdSuccess : MessageBase
    {
        public EventDto EventDto { get; }

        public GetEventByIdSuccess(Guid requestId, EventDto eventDto) : base(requestId)
        {
            EventDto = eventDto;
        }
    }
}
