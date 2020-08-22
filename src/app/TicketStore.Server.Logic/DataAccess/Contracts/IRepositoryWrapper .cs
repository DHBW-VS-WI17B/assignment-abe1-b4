using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TicketStore.Server.Logic.DataAccess.Contracts
{
    /// <summary>
    /// Wrapper around all repositories for easier access.
    /// </summary>
    public interface IRepositoryWrapper : IReadonlyRepositoryWrapper
    {
        /// <summary>
        /// Save changes in the repositories.
        /// </summary>
        Task SaveAsync();
    }
}
