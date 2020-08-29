using System;
using System.Collections.Immutable;
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
        public ImmutableList<TicketDto> TicketDtos { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="ticketDto">Immutable list of tickets.</param>
        /// <param name="errorMessage">Error message.</param>
        public AddTicketsToDbResponse(Guid requestId, ImmutableList<TicketDto> ticketDtos, string errorMessage = null) : base(requestId, errorMessage)
        {
            TicketDtos = ticketDtos;
        }
    }
}
