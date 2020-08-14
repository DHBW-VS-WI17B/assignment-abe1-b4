using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Server.Contracts
{
    /// <summary>
    /// Wrapper around all repositories for easier access.
    /// </summary>
    public interface IRepositoryWrapper
    {
        /// <summary>
        /// User entity repository.
        /// </summary>
        IUserRepository User { get; }

        /// <summary>
        /// Event entity repository.
        /// </summary>
        IEventRepository Event { get;  }

        /// <summary>
        /// PostalAddress entity repository.
        /// </summary>
        IPostalAddressRepository PostalAddress { get; }

        /// <summary>
        /// Ticket entity repository.
        /// </summary>
        ITicketRepository Ticket { get;  }

        /// <summary>
        /// Save changes in the repositories.
        /// </summary>
        void Save();
    }
}
