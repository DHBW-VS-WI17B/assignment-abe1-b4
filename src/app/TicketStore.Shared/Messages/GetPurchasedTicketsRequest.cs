using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Enums;
using TicketStore.Shared.Models;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Immutable get purchased tickets request message.
    /// </summary>
    public class GetPurchasedTicketsRequest : MessageBase
    {
        /// <summary>
        /// User id.
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// Ticket sorting information.
        /// </summary>
        public TicketSorting TicketSorting { get; }

        /// <summary>
        /// Ticket filter information.
        /// </summary>
        public TicketFilter TicketFilter { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="userId">User id.</param>
        /// <param name="ticketSorting">Ticket sorting information.</param>
        /// <param name="ticketFilter">Ticket filter information.</param>
        public GetPurchasedTicketsRequest(Guid requestId, Guid userId, TicketSorting ticketSorting, TicketFilter ticketFilter) : base(requestId)
        {
            UserId = userId;
            TicketSorting = ticketSorting;
            TicketFilter = ticketFilter;
        }
    }
}
