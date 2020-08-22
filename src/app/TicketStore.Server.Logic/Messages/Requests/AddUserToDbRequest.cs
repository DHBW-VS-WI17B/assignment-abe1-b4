using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Messages;
using TicketStore.Shared.Models;

namespace TicketStore.Server.Logic.Messages.Requests
{
    /// <summary>
    /// Immutable add user to db request message.
    /// </summary>
    public class AddUserToDbRequest : MessageBase
    {
        /// <summary>
        /// User to be added.
        /// </summary>
        public UserDto UserDto { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="userDto">User to be added.</param>
        public AddUserToDbRequest(Guid requestId, UserDto userDto) : base(requestId)
        {
            UserDto = userDto;
        }
    }
}
