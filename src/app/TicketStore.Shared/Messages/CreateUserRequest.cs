using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Messages;
using TicketStore.Shared.Models;

namespace TicketStore.Shared.Messages
{
    public class CreateUserRequest : MessageBase
    {
        public UserDto UserDto { get; }

        public CreateUserRequest(Guid requestId, UserDto userDto) : base(requestId)
        {
            UserDto = userDto;
        }
    }
}
