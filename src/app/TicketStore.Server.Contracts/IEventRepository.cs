using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Entities.Models;

namespace TicketStore.Server.Contracts
{
    /// <summary>
    /// Event repository.
    /// </summary>
    public interface IEventRepository : IRepositoryBase<Event>
    {
    }
}
