using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Contracts;
using TicketStore.Server.Entities;
using TicketStore.Server.Entities.Models;

namespace TicketStore.Server.DataAccess
{
    public class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
    {
        public TicketRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
