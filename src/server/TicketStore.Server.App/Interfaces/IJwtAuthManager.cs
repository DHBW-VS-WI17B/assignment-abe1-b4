using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketStore.Server.App.Interfaces
{
    public interface IJwtAuthManager
    {
        string Authenticate(string username, string password);
    }
}
