using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Immutable get purchased tickets success message.
    /// </summary>
    public class GetPurchasedTicketsSuccess : MessageBase
    {
        /// <summary>
        /// Immutable list of sorted tickets.
        /// </summary>
        public IImmutableList<RichTicketDto> Tickets { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="tickets">Immutable list of sorted tickets.</param>
        public GetPurchasedTicketsSuccess(Guid requestId, IImmutableList<RichTicketDto> tickets) : base(requestId)
        {
            Tickets = tickets;
        }
    }
}
