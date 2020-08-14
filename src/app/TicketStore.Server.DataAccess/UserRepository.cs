using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TicketStore.Server.Contracts;
using TicketStore.Server.Entities;
using TicketStore.Server.Entities.Models;

namespace TicketStore.Server.DataAccess
{
    /// <summary>
    /// User repository.
    /// </summary>
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repositoryContext">Repository context.</param>
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
