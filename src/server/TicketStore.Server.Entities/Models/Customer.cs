using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Server.Entities.Models
{
    /// <summary>
    /// A customer who attends events.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Unique id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Total amount of money a customer can spend on tickets per year.
        /// </summary>
        public float YearlyBudget { get; set; }

        /// <summary>
        /// Name of the customer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Address of the customer.
        /// </summary>
        public PostalAddress Address { get; set; }

        /// <summary>
        /// List of purchased tickets and purchase date.
        /// </summary>
        public IEnumerable<Ticket> PurchasedTickets { get; set; }

        /// <summary>
        /// The purchase price of the ticket.
        /// </summary>
        public float Price { get; set; }

    }
}
