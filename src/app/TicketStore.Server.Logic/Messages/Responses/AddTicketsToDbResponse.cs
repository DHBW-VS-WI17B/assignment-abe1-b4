using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Server.Logic.Messages.Responses
{
    /// <summary>
    /// Immutable add ticket to database response message.
    /// </summary>
    public class AddTicketsToDbResponse : ResponseBase
    {
        /// <summary>
        /// Ticket data.
        /// </summary>
        public ImmutableList<TicketDto> TicketDtos { get; } // TODO: has to be an immutable collection of tickets

        /// <summary>
        /// Costs of the purchase.
        /// </summary>
        public double Costs { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="ticketDto">Immutable list of tickets.</param>
        /// <param name="costs">Costs of the purchase.</param>
        /// <param name="errorMessage">Error message.</param>
        public AddTicketsToDbResponse(Guid requestId, ImmutableList<TicketDto> ticketDtos, double costs, string errorMessage = null) : base(requestId, errorMessage)
        {
            TicketDtos = ticketDtos;
            Costs = costs;
        }
    }
}
