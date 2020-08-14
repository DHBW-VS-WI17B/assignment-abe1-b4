using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Entities.Models;

namespace TicketStore.Server.Contracts
{
    public interface IEventRepository : IRepositoryBase<Event>
    {
    }
}
