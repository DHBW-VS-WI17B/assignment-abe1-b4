using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketStore.Server.App.Resources
{
    public class CreateEventResource
    {
        /// <summary>
        /// Name of the event.
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// When the event takes place.
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Where the event takes place.
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Location { get; set; }

        /// <summary>
        /// Price of one ticket for the event.
        /// </summary>
        [Required]
        public float PricePerTicket { get; set; }

        /// <summary>
        /// Maximum count of tickets available.
        /// </summary>
        [Required]
        public int MaxTicketCount { get; set; }

        /// <summary>
        /// Maximum count of tickets a user can buy.
        /// </summary>
        [Required]
        public int MaxTicketsPerUser { get; set; }

        /// <summary>
        /// Sales start date.
        /// </summary>
        [Required]
        public DateTime SalesStartDate { get; set; }

        /// <summary>
        /// Duration of a sale.
        /// </summary>
        [Required]
        public TimeSpan SaleDuration { get; set; }
    }
}
