using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Get user by user name response.
    /// </summary>
    public sealed class GetUserByUserNameResponse : ResponseBase
    {
        /// <summary>
        /// User with given username.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Error constructor.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        public GetUserByUserNameResponse(string errorMessage) : base (errorMessage) {}

        /// <summary>
        /// Success constructor.
        /// </summary>
        /// <param name="user">User with given username.</param>
        public GetUserByUserNameResponse(User user) : base()
        {
            User = user;
        }
    }
}
