using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Contracts;
using TicketStore.Server.Entities;
using TicketStore.Server.Entities.Models;

namespace TicketStore.Server.DataAccess
{
    /// <summary>
    /// Postal address repository.
    /// </summary>
    public class PostalAddressRepository : RepositoryBase<PostalAddress>, IPostalAddressRepository
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repositoryContext">Repository context.</param>
        public PostalAddressRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
