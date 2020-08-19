using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Models
{
    /// <summary>
    /// Represents a happening.
    /// </summary>
    public class Happening
    {
        /// <summary>
        /// Unique id.
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// Name of the happening.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// When the happening takes place.
        /// </summary>
        public DateTimeOffset Date { get; set; }

        /// <summary>
        /// Where the happening takes place.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Price of one ticket for the happening.
        /// </summary>
        public double PricePerTicket { get; set; }

        /// <summary>
        /// Maximum count of tickets available.
        /// </summary>
        public int MaxTicketCount { get; set; }

        /// <summary>
        /// Maximum count of tickets a user can buy.
        /// </summary>
        public int MaxTicketsPerUser { get; set; }

        /// <summary>
        /// Sales start date.
        /// </summary>
        public DateTimeOffset SalesStartDate { get; set; }

        /// <summary>
        /// Duration of a sale.
        /// </summary>
        public TimeSpan SaleDuration { get; set; }
    }
}
