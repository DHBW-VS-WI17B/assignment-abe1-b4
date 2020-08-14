using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketStore.Server.App.Resources
{
    /// <summary>
    /// Authentication response resource.
    /// </summary>
    public class AuthResponseResource
    {
        /// <summary>
        /// Json web token.
        /// </summary>
        public string Jwt { get; set; }
    }
}
