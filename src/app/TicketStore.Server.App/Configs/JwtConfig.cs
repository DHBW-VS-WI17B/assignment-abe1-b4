using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketStore.Server.App.Configs
{
    /// <summary>
    /// Json web token config.
    /// </summary>
    public class JwtConfig
    {
        /// <summary>
        /// Secret used to sign tokens.
        /// </summary>
        public string Secret { get; set; }
    }
}
