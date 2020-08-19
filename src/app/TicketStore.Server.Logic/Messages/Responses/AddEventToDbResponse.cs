using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Responses;

namespace TicketStore.Server.Logic.Messages.Responses
{
    public sealed class AddEventToDbResponse : ResponseBase
    {
        public Guid EventId { get; }

        public AddEventToDbResponse(Guid requestId, Guid eventId) : base(requestId)
        {
            EventId = eventId;
        }

        public AddEventToDbResponse(Guid requestId, string errorMessage) : base(requestId, errorMessage)
        {

        }
    }
}
