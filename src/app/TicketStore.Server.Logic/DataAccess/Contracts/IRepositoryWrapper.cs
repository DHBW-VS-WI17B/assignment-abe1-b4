using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TicketStore.Server.Logic.DataAccess.Contracts
{
    /// <summary>
    /// Wrapper around all repositories for easier access.
    /// </summary>
    public interface IRepositoryWrapper
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

        /// <summary>
        /// Save changes in the repositories.
        /// </summary>
        Task SaveAsync();
    }
}
