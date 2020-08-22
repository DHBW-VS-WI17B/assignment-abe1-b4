using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TicketStore.Server.Logic.DataAccess.Contracts
{
    /// <summary>
    /// Readonly wrapper around all repositories for easier access.
    /// </summary>
    public interface IReadonlyRepositoryWrapper
    {
        /// <summary>
        /// User entity repository.
        /// </summary>
        IUserRepository Users { get; }

        /// <summary>
        /// Event entity repository.
        /// </summary>
        IEventRepository Events { get; }

        /// <summary>
        /// PostalAddress entity repository.
        /// </summary>
        IAddressRepository Addresses { get; }

        /// <summary>
        /// Ticket entity repository.
        /// </summary>
        ITicketRepository Tickets { get; }
    }
}
