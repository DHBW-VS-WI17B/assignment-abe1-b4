using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Messages;
using TicketStore.Shared.Models;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Immutable create user request message.
    /// </summary>
    public class CreateUserRequest : MessageBase
    {
        /// <summary>
        /// User to be created.
        /// </summary>
        public UserDto UserDto { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="userDto">User to be created.</param>
        public CreateUserRequest(Guid requestId, UserDto userDto) : base(requestId)
        {
            UserDto = userDto;
        }
    }
}
