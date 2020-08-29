using TicketStore.Server.Logic.DataAccess.Contracts;
using TicketStore.Server.Logic.DataAccess.Entities;

namespace TicketStore.Server.Logic.DataAccess
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
        public EventRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
