using System;
using System.ComponentModel.DataAnnotations;

namespace TicketStore.Server.Logic.DataAccess.Entities
{
    /// <summary>
    /// Ticket.
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
        /// User id foreign key.
        /// </summary>
        public Guid UserId { get; set; }
    }
}
