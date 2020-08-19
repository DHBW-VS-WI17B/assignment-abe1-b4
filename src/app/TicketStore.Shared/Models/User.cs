using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Models
{
    /// <summary>
    /// User model.
    /// </summary>
    public class User
    {
        /// <summary>
        /// User id.
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// Is admin.
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Name of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Postal address of the user.
        /// </summary>
        public Address Address { get; set; }
    }
}
