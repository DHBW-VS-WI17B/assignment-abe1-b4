using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// When the ticket was purchased
        /// </summary>
        [Required]
        public DateTime PurchaseDate { get; set; }


        /// <summary>
        /// Event id foreign key.
        /// </summary>
        [Required]
        public Guid EventId { get; set; }

        /// <summary>
        /// Event this ticket was purchased for.
        /// </summary>
        [Required]
        public Event Event { get; set; }

        /// <summary>
        /// User id foreign key.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// User who bought this ticket.
        /// </summary>
        public User User { get; set; }
    }
}
