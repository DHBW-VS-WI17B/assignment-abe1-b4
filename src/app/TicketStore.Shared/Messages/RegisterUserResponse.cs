using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Register user response.
    /// </summary>
    public sealed class RegisterUserResponse : ResponseBase
    {
        /// <summary>
        /// Registered user.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Success constructor.
        /// </summary>
        /// <param name="user">Registered user.</param>
        public RegisterUserResponse(User user) : base()
        {
            User = user;
        }

        /// <summary>
        /// Error constructor.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        public RegisterUserResponse(string errorMessage) : base(errorMessage) {}
    }
}
