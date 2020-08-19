using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Get user by user name request.
    /// </summary>
    public sealed class GetUserByUserNameRequest
    {
        /// <summary>
        /// User name.
        /// </summary>
        public string UserName { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="userName">User name.</param>
        public GetUserByUserNameRequest(string userName)
        {
            UserName = userName;
        }
    }
}
 