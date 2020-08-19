using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // to be replaced in production :)
            optionsBuilder.UseInMemoryDatabase("app");
        }
    }
}
