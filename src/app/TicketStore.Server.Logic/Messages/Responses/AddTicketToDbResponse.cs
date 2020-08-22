using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Server.Logic.Messages.Responses
{
    public class AddTicketToDbResponse : ResponseBase
    {
        public TicketDto TicketDto { get; }

        public double Costs { get; }

        public AddTicketToDbResponse(Guid requestId, TicketDto ticketDto, double costs, string errorMessage = null) : base(requestId, errorMessage)
        {
            TicketDto = ticketDto;
            Costs = costs;
        }
    }
}
