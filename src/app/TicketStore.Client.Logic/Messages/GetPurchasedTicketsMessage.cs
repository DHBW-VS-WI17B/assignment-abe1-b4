using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Client.Logic.Messages
{
    public class GetPurchasedTicketsMessage
    {
        public string SortBy { get; }
        public string OrderBy { get; }

        public GetPurchasedTicketsMessage(string sortBy, string orderBy)
        {
            SortBy = sortBy;
            OrderBy = orderBy;
        }
    }
}
