using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Messages;
using TicketStore.Shared.Models;

namespace TicketStore.Server.Logic.Messages.Requests
{
    public class AddEventToDbRequest : MessageBase
    {
        public EventDto EventDto { get; }

        public AddEventToDbRequest(Guid messageId, EventDto eventDto) : base(messageId)
        {
            EventDto = eventDto;
        }
    }
}
