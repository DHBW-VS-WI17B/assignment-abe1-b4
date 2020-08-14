using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketStore.Server.App.Resources
{
    public class AuthRequestResource
    {
        [Required]
        [MaxLength(128)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(256)]
        public string Password { get; set; }
    }
}
