using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Shared.Messages
{
    public class PurchaseTicketSuccess : MessageBase
    {
        public TicketDto TicketDto { get; }

        public double Costs { get; }

        public PurchaseTicketSuccess(Guid requestId, TicketDto ticketDto, double costs) : base(requestId)
        {
            TicketDto = ticketDto;
            Costs = costs;
        }
    }
}
