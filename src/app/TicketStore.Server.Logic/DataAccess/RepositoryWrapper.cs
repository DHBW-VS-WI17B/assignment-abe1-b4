using System.Threading.Tasks;
using TicketStore.Server.Logic.DataAccess.Contracts;

namespace TicketStore.Server.Logic.DataAccess
{
    /// <summary>
    /// Repository wrapper implementation.
    /// </summary>
    public class RepositoryWrapper : ReadonlyRepositoryWrapper, IRepositoryWrapper
    {
        /// <inheritdoc/>
        public RepositoryWrapper(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        /// <inheritdoc/>
        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
