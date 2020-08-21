using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;
using TicketStore.Shared.Requests;

namespace TicketStore.Server.Logic.Messages.Requests
{
    public class AddUserToDbRequest : RequestBase
    {
        public UserDto UserDto { get; }

        public AddUserToDbRequest(UserDto userDto)
        {
            UserDto = userDto;
        }
    }
}
