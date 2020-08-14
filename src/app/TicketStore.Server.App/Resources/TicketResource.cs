using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketStore.Server.App.Resources
{
    public class TicketResource
    {
        /// <summary>
        /// Unique id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// When the ticket was purchased
        /// </summary>
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// Event id foreign key.
        /// </summary>
        public Guid EventId { get; set; }

        /// <summary>
        /// User id foreign key.
        /// </summary>
        public Guid UserId { get; set; }
    }
}
