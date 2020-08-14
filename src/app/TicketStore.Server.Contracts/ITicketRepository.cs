using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Entities.Models;

namespace TicketStore.Server.Contracts
{
    /// <summary>
    /// Ticket repository.
    /// </summary>
    public interface ITicketRepository : IRepositoryBase<Ticket>
    {
    }
}
