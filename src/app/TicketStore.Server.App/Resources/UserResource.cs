using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketStore.Server.App.Resources
{
    public class UserResource
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
        public bool IsAdmin { get; set; }

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
        public PostalAddressResource PostalAddress { get; set; }
    }
}
