using TicketStore.Server.Logic.DataAccess.Contracts;

namespace TicketStore.Server.Logic.DataAccess
{
    /// <summary>
    /// Readonly repository wrapper implementation.
    /// </summary>
    public class ReadonlyRepositoryWrapper : IReadonlyRepositoryWrapper
    {
        internal readonly RepositoryContext _repositoryContext;
        private IUserRepository _userRepo;
        private IEventRepository _eventRepo;
        private IAddressRepository _adressRepo;
        private ITicketRepository _ticketRepo;

        /// <inheritdoc/>
        public IUserRepository Users
        {
            get
            {
                if (_userRepo == null)
                {
                    _userRepo = new UserRepository(_repositoryContext);
                }

                return _userRepo;
            }
        }

        /// <inheritdoc/>
        public IEventRepository Events
        {
            get
            {
                if (_eventRepo == null)
                {
                    _eventRepo = new EventRepository(_repositoryContext);
                }

                return _eventRepo;
            }
        }

        /// <inheritdoc/>
        public IAddressRepository Addresses
        {
            get
            {
                if (_adressRepo == null)
                {
                    _adressRepo = new AddressRepository(_repositoryContext);
                }

                return _adressRepo;
            }
        }

        /// <inheritdoc/>
        public ITicketRepository Tickets
        {
            get
            {
                if (_ticketRepo == null)
                {
                    _ticketRepo = new TicketRepository(_repositoryContext);
                }

                return _ticketRepo;
            }
        }

        /// <inheritdoc/>
        public ReadonlyRepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
    }
}
