using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Messages;
using TicketStore.Shared.Models;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Immmutable create user success message.
    /// </summary>
    public class CreateUserSuccess : MessageBase
    {
        /// <summary>
        /// Created user.
        /// </summary>
        public UserDto UserDto { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="userDto">Created user.</param>
        public CreateUserSuccess(Guid requestId, UserDto userDto) : base (requestId)
        {
            UserDto = userDto;
        }
    }
}
