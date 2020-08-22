using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Messages;
using TicketStore.Shared.Models;

namespace TicketStore.Server.Logic.Messages.Requests
{
    public class AddUserToDbRequest : MessageBase
    {
        public UserDto UserDto { get; }

        public AddUserToDbRequest(Guid requestId, UserDto userDto) : base(requestId)
        {
            UserDto = userDto;
        }
    }
}
