using System;
using System.Collections.Generic;
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
        public Guid Id { get; set; }

        /// <summary>
        /// Total amount of money a user can spend on tickets per year.
        /// </summary>
        public float YearlyBudget { get; set; }

        /// <summary>
        /// Role of the user.
        /// </summary>
        public UserRole Role { get; set; }

        /// <summary>
        /// Name of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Unencrypted password.
        /// We are aware that this is a bad practice.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Address of the user.
        /// </summary>
        public PostalAddress Address { get; set; }
    }
}
