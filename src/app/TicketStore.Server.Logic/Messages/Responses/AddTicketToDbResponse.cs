using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Server.Logic.Messages.Responses
{
    /// <summary>
    /// Immutable add ticket to database response message.
    /// </summary>
    public class AddTicketToDbResponse : ResponseBase
    {
        /// <summary>
        /// Ticket data.
        /// </summary>
        public TicketDto TicketDto { get; } // TODO: has to be an immutable collection of tickets

        /// <summary>
        /// Costs of the purchase.
        /// </summary>
        public double Costs { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="ticketDto">Ticket data.</param>
        /// <param name="costs">Costs of the purchase.</param>
        /// <param name="errorMessage">Error message.</param>
        public AddTicketToDbResponse(Guid requestId, TicketDto ticketDto, double costs, string errorMessage = null) : base(requestId, errorMessage)
        {
            TicketDto = ticketDto;
            Costs = costs;
        }
    }
}
