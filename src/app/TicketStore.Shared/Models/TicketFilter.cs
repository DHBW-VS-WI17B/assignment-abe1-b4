using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Enums;

namespace TicketStore.Shared.Models
{
    /// <summary>
    /// Ticker filter information.
    /// </summary>
    public class TicketFilter
    {
        /// <summary>
        /// Filter by criterion.
        /// </summary>
        public QueryCriterion Criterion { get; }

        /// <summary>
        /// Filter date time. Only the day is considered.
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="criterion">Filter by criterion.</param>
        /// <param name="date">Filter date time. Only the day is considered.</param>
        public TicketFilter(QueryCriterion criterion, DateTime date)
        {
            Criterion = criterion;
            Date = date;
        }
    }
}
