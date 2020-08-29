using System;
using System.Collections.Immutable;
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
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="ticketDto">Immutable list of purchased tickets.</param>
        /// <param name="costs">Costs.</param>
        public PurchaseTicketsSuccess(Guid requestId, ImmutableList<TicketDto> ticketDtos) : base(requestId)
        {
            TicketDtos = ticketDtos;
        }
    }
}
