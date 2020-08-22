using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Client.Logic.Messages
{
    public class GetPurchasedTicketsMessage
    {
        public string SortBy { get; }
        public string Order { get; }

        public GetPurchasedTicketsMessage(string sortBy, string order)
        {
            SortBy = sortBy;
            Order = order;
        }
    }
}
