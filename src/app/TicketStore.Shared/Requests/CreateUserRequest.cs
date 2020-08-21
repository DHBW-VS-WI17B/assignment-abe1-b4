using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Shared.Requests
{
    public class CreateUserRequest : RequestBase
    {
        public UserDto UserDto { get; }

        public CreateUserRequest(UserDto userDto)
        {
            UserDto = userDto;
        }
    }
}
