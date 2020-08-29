using TicketStore.Server.Logic.DataAccess.Contracts;
using TicketStore.Server.Logic.DataAccess.Entities;

namespace TicketStore.Server.Logic.DataAccess
{
    /// <summary>
    /// Address repository.
    /// </summary>
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repositoryContext">Repository context.</param>
        public AddressRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
