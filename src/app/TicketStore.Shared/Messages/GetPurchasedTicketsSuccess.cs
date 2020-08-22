using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Shared.Messages
{
    public class GetPurchasedTicketsSuccess : MessageBase
    {
        public IImmutableList<RichTicketDto> Tickets { get; }

        public GetPurchasedTicketsSuccess(Guid requestId, IImmutableList<RichTicketDto> tickets) : base(requestId)
        {
            Tickets = tickets;
        }
    }
}
