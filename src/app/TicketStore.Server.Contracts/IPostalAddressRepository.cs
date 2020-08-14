using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Entities.Models;

namespace TicketStore.Server.Contracts
{
    /// <summary>
    /// Postal address repository.
    /// </summary>
    public interface IPostalAddressRepository : IRepositoryBase<PostalAddress>
    {
    }
}
