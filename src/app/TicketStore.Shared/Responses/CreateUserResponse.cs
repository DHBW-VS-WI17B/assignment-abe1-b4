using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Shared.Responses
{
    public class CreateUserResponse : ResponseBase
    {
        public UserDto UserDto { get; set; }

        public CreateUserResponse(Guid requestId, string errorMessage) : base (requestId, errorMessage){ }

        public CreateUserResponse(Guid requestId, UserDto userDto) : base (requestId)
        {
            UserDto = userDto;
        }
    }
}
