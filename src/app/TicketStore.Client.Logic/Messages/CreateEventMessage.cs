using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Client.Logic.Messages
{
    public class CreateEventMessage
    {
        public EventDto EventDto { get; }

        public CreateEventMessage(EventDto eventDto)
        {
            EventDto = eventDto;
        }
    }
}
