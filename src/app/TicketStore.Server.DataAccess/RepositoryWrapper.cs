using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Contracts;
using TicketStore.Server.Entities;

namespace TicketStore.Server.DataAccess
{
    /// <summary>
    /// Repository wrapper implementation.
    /// </summary>
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repositoryContext;
        private IUserRepository _user;
        private IEventRepository _event;
        private IPostalAddressRepository _postalAddress;
        private ITicketRepository _ticket;

        /// <inheritdoc/>
        public IUserRepository User
        {
            get
            {
                if(_user == null)
                {
                    _user = new UserRepository(_repositoryContext);
                }

                return _user;
            }
        }

        /// <inheritdoc/>
        public IEventRepository Event
        {
            get
            {
                if (_event == null)
                {
                    _event = new EventRepository(_repositoryContext);
                }

                return _event;
            }
        }

        /// <inheritdoc/>
        public IPostalAddressRepository PostalAddress
        {
            get
            {
                if (_postalAddress == null)
                {
                    _postalAddress = new PostalAddressRepository(_repositoryContext);
                }

                return _postalAddress;
            }
        }

        /// <inheritdoc/>
        public ITicketRepository Ticket
        {
            get
            {
                if (_ticket == null)
                {
                    _ticket = new TicketRepository(_repositoryContext);
                }

                return _ticket;
            }
        }

        /// <inheritdoc/>
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        /// <inheritdoc/>
        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
