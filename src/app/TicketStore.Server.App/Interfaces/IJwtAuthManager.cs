using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketStore.Server.App.Interfaces
{
    /// <summary>
    /// Interface for a json web token authentication handler.
    /// </summary>
    public interface IJwtAuthManager
    {
        /// <summary>
        /// Authenticates a user.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>Json web token.</returns>
        string Authenticate(string username, string password);
    }
}
