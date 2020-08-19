using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Logic.DataAccess.Contracts;
using TicketStore.Server.Logic.DataAccess.Entities;

namespace TicketStore.Server.Logic.DataAccess
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
