using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Server.Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IEventRepository Event { get;  }
        IPostalAddressRepository PostalAddress { get; }
        ITicketRepository Ticket { get;  }
        void Save();
    }
}
