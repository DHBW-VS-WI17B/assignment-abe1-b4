using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Contracts;
using TicketStore.Server.Entities;
using TicketStore.Server.Entities.Models;

namespace TicketStore.Server.DataAccess
{
    public class PostalAddressRepository : RepositoryBase<PostalAddress>, IPostalAddressRepository
    {
        public PostalAddressRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
