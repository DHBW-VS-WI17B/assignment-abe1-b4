using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Enums;

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
        /// Sort order.
        /// </summary>
        public Order Order { get; }

        /// <summary>
        /// Sort criterion.
        /// </summary>
        public Sort SortBy { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="userId">User id.</param>
        /// <param name="order">Order direction.</param>
        /// <param name="sortBy">Sort criterion.</param>
        public GetPurchasedTicketsRequest(Guid requestId, Guid userId, Order order, Sort sortBy) : base(requestId)
        {
            UserId = userId;
            Order = order;
            SortBy = sortBy;
        }
    }
}
