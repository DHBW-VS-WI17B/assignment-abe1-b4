using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Logic.DataAccess.Entities;

namespace TicketStore.Server.Logic.DataAccess.Contracts
{
    /// <summary>
    /// Ticket repository.
    /// </summary>
    public interface ITicketRepository : IRepositoryBase<Ticket>
    {
    }
}
