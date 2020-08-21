using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Messages;
using TicketStore.Shared.Models;

namespace TicketStore.Shared.Messages
{
    public class CreateUserSuccess : MessageBase
    {
        public UserDto UserDto { get; set; }

        public CreateUserSuccess(Guid requestId, UserDto userDto) : base (requestId)
        {
            UserDto = userDto;
        }
    }
}
