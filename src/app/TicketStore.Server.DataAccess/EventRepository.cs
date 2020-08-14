using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Contracts;
using TicketStore.Server.Entities;
using TicketStore.Server.Entities.Models;

namespace TicketStore.Server.DataAccess
{
    /// <summary>
    /// Event repository.
    /// </summary>
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repositoryContext">Repository context.</param>
        public EventRepository(RepositoryContext repositoryContext) : base (repositoryContext)
        {
        }
    }
}
