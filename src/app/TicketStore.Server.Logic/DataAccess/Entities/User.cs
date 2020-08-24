using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketStore.Server.Logic.DataAccess.Entities
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
        /// Name of the user.
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Address of the user.
        /// </summary>
        [Required]
        public Address Address { get; set; }

        /// <summary>
        /// Yearly budget of money units for ticket purchases (for events in the same year).
        /// </summary>
        public double YearlyBudget { get; set; }
    }
}
