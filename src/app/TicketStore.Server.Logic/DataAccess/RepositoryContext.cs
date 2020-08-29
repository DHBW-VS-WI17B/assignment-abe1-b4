using Microsoft.EntityFrameworkCore;
using TicketStore.Server.Logic.DataAccess.Entities;

namespace TicketStore.Server.Logic.DataAccess
{
    /// <summary>
    /// Repository context.
    /// </summary>
    public class RepositoryContext : DbContext
    {
        /// <summary>
        /// User set.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Event set.
        /// </summary>
        public DbSet<Event> Events { get; set; }

        /// <summary>
        /// Postal address set.
        /// </summary>
        public DbSet<Address> Addresses { get; set; }

        /// <summary>
        /// Ticket set.
        /// </summary>
        public DbSet<Ticket> Tickets { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="options">Options to be passed to the base constructor.</param>
        public RepositoryContext(DbContextOptions options) : base(options) { }
    }
}
