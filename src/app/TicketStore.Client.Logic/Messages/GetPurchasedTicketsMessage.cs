using System;

namespace TicketStore.Client.Logic.Messages
{
    /// <summary>
    /// Immutable get purchased tickets message.
    /// </summary>
    public class GetPurchasedTicketsMessage
    {
        /// <summary>
        /// Sort by criterion.
        /// </summary>
        public string SortBy { get; }

        /// <summary>
        /// Order direction. Either ascending or descending.
        /// </summary>
        public string OrderDirection { get; }

        /// <summary>
        /// Filter by criterion.
        /// </summary>
        public string FilterBy { get; }

        /// <summary>
        /// Filter date time. Only the day is considered.
        /// </summary>
        public DateTime? FilterDateTime { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sortBy">Sort by criterion.</param>
        /// <param name="order">Order direction. Either ascending or descending.</param>
        /// <param name="filterBy">Filter by criterion.</param>
        /// <param name="filterDateTime">Filter date time. Only the day is considered.</param>
        public GetPurchasedTicketsMessage(string sortBy, string order, string filterBy, DateTime? filterDateTime)
        {
            SortBy = sortBy;
            OrderDirection = order;
            FilterBy = filterBy;
            FilterDateTime = filterDateTime;
        }
    }
}
