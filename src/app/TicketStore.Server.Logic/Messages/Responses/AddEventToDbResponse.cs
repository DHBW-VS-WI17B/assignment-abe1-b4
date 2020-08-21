using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Server.Logic.Messages.Responses
{
    public class AddEventToDbResponse : ResponseBase
    {
        public EventDto EventDto { get; }

        public AddEventToDbResponse(Guid requestId, EventDto eventDto, string errorMessage = null) : base(requestId, errorMessage)
        {
            EventDto = eventDto;
        }
    }
}
