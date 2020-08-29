using System;
using TicketStore.Shared.Models;

namespace TicketStore.Server.Logic.Messages.Responses
{
    /// <summary>
    /// Immutable add user to database response message.
    /// </summary>
    public class AddUserToDbResponse : ResponseBase
    {
        /// <summary>
        /// Added user.
        /// </summary>
        public UserDto UserDto { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="userDto">Added user.</param>
        /// <param name="errorMessage">Error message.</param>
        public AddUserToDbResponse(Guid requestId, UserDto userDto, string errorMessage = null) : base(requestId, errorMessage)
        {
            UserDto = userDto;
        }
    }
}
