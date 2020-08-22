using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Client.Logic.Messages
{
    /// <summary>
    /// Immutable get purchased tickets message.
    /// </summary>
    public class GetPurchasedTicketsMessage
    {
        /// <summary>
        /// Sort by cirteria.
        /// </summary>
        public string SortBy { get; }

        /// <summary>
        /// Order ascending or descending.
        /// </summary>
        public string Order { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sortBy">Sort by cirteria.</param>
        /// <param name="order">Order ascending or descending.</param>
        public GetPurchasedTicketsMessage(string sortBy, string order)
        {
            SortBy = sortBy;
            Order = order;
        }
    }
}
