using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Entities.Models;

namespace TicketStore.Server.Entities
{
    /// <summary>
    /// Repository context.
    /// </summary>
    public class RepositoryContext : DbContext
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="options">Options to be passed to the base constructor.</param>
        public RepositoryContext(DbContextOptions options) : base (options) {}

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
        public DbSet<PostalAddress> PostalAddresses { get; set; }

        /// <summary>
        /// Ticket set.
        /// </summary>
        public DbSet<Ticket> Tickets { get; set; }
    }
}
