using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketStore.Server.App.Resources
{
    /// <summary>
    /// Authentication request resource.
    /// </summary>
    public class AuthRequestResource
    {
        /// <summary>
        /// User name.
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string UserName { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Password { get; set; }
    }
}
