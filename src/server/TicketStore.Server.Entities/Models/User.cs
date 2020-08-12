using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketStore.Server.Entities.Models
{
    /// <summary>
    /// A user who purchases tickets for events.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Unique id.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Total amount of money a user can spend on tickets per year.
        /// </summary>
        [Required]
        public float YearlyBudget { get; set; }

        /// <summary>
        /// Role of the user.
        /// </summary>
        [Required]
        public UserRole Role { get; set; }

        /// <summary>
        /// Name of the user.
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Unencrypted password.
        /// We are aware that this is a bad practice.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Address of the user.
        /// </summary>
        [Required]
        public PostalAddress PostalAddress { get; set; }

        /// <summary>
        /// List of tickets that the user has purchased.
        /// </summary>
        [Required]
        public List<Ticket> PurchasedTickets { get; set; } = new List<Ticket>();
    }
}
