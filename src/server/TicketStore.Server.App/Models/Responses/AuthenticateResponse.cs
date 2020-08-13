using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketStore.Server.App.Models.Responses
{
    public class AuthenticateResponse
    {
        public string Jwt { get; set; }
    }
}
