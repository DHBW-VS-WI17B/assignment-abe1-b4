using System;
using System.Collections.Generic;
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
        public TicketDto TicketDto { get; } // TODO should be a list of tickets.

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
        public PurchaseTicketsSuccess(Guid requestId, TicketDto ticketDto, double costs) : base(requestId)
        {
            TicketDto = ticketDto;
            Costs = costs;
        }
    }
}
