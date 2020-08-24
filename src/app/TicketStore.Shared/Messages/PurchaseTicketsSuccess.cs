using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Immutable purchase ticket success message.
    /// </summary>
    public class PurchaseTicketsSuccess : MessageBase
    {
        /// <summary>
        /// Immutable list of purchased tickets.
        /// </summary>
        public ImmutableList<TicketDto> TicketDtos { get; }

        /// <summary>
        /// Costs to deduct from the local budget.
        /// </summary>
        public double Costs { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="ticketDto">Immutable list of purchased tickets.</param>
        /// <param name="costs">Costs.</param>
        public PurchaseTicketsSuccess(Guid requestId, ImmutableList<TicketDto> ticketDtos, double costs) : base(requestId)
        {
            TicketDtos = ticketDtos;
            Costs = costs;
        }
    }
}
