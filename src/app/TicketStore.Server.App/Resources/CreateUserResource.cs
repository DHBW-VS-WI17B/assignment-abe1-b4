using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketStore.Server.App.Resources
{
    public class CreateUserResource
    {
        /// <summary>
        /// Total amount of money a user can spend on tickets per year.
        /// </summary>
        [Required]
        public float YearlyBudget { get; set; }

        /// <summary>
        /// Role of the user.
        /// </summary>
        [Required]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Name of the user.
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string UserName { get; set; }

        /// <summary>
        /// Unencrypted password.
        /// We are aware that this is a bad practice.
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Password { get; set; }

        /// <summary>
        /// Address of the user.
        /// </summary>
        [Required]
        public PostalAddressResource PostalAddress { get; set; }
    }
}
