using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Entities.Models;

namespace TicketStore.Server.Contracts
{
    /// <summary>
    /// User repository.
    /// </summary>
    public interface IUserRepository : IRepositoryBase<User>
    {
    }
}
