using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Logic.DataAccess.Entities;

namespace TicketStore.Server.Logic.DataAccess.Contracts
{
    /// <summary>
    /// Postal address repository.
    /// </summary>
    public interface IAddressRepository : IRepositoryBase<Address>
    {
    }
}
