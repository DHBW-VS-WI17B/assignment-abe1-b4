using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Server.Entities.Models
{
    /// <summary>
    /// Ticket for an <see cref="TicketStore.Server.Entities.Event"/>.
    /// </summary>
    public class Ticket
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
        /// Price of the ticket.
        /// </summary>
        public float Price { get; set; }
    }
}
