using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Enums;

namespace TicketStore.Shared.Models
{
    /// <summary>
    /// Ticket sorting information.
    /// </summary>
    public class TicketSorting
    {
        /// <summary>
        /// Sort by criterion.
        /// </summary>
        public QueryCriterion Criterion { get; }

        /// <summary>
        /// Order direction.
        /// </summary>
        public OrderDirection OrderDirection { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="criterion">Sort by criterion.</param>
        /// <param name="orderDirection">Order direction.</param>
        public TicketSorting(QueryCriterion criterion, OrderDirection orderDirection)
        {
            Criterion = criterion;
            OrderDirection = orderDirection;
        }
    }
}
