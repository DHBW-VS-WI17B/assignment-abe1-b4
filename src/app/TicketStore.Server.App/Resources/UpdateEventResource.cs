using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketStore.Server.App.Resources
{
    public class UpdateEventResource
    {
        /// <summary>
        /// Name of the event.
        /// </summary>
        [MaxLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// When the event takes place.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Where the event takes place.
        /// </summary>
        [MaxLength(256)]
        public string Location { get; set; }

        /// <summary>
        /// Price of one ticket for the event.
        /// </summary>
        public float PricePerTicket { get; set; }

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
        public DateTime SalesStartDate { get; set; }

        /// <summary>
        /// Duration of a sale.
        /// </summary>
        public TimeSpan SaleDuration { get; set; }
    }
}
