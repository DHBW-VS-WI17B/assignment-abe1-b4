using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TicketStore.Server.Entities.Models
{
    /// <summary>
    /// Represents an event.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Unique id.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the event.
        /// </summary>
        [Required]
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

        /// <summary>
        /// Sold tickets.
        /// </summary>
        [Required]
        public List<Ticket> SoldTickets { get; set; } = new List<Ticket>();
    }
}
    