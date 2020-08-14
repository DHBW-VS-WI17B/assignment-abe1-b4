using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Contracts;
using TicketStore.Server.Entities;
using TicketStore.Server.Entities.Models;

namespace TicketStore.Server.DataAccess
{
    /// <summary>
    /// Ticket repository.
    /// </summary>
    public class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repositoryContext">Repository context.</param>
        public TicketRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
