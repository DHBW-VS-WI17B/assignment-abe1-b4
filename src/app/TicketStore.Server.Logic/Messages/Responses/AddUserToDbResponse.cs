using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;
using TicketStore.Shared.Responses;

namespace TicketStore.Server.Logic.Messages.Responses
{
    public class AddUserToDbResponse : ResponseBase
    {
        public UserDto UserDto { get; }

        public AddUserToDbResponse(Guid requestId, string errorMessage) : base(requestId, errorMessage) { }

        public AddUserToDbResponse(Guid requestId, UserDto userDto) : base(requestId)
        {
            UserDto = userDto;
        }
    }
}
