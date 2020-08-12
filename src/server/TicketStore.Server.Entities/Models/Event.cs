using System;
using System.Collections;
using System.Collections.Generic;

namespace TicketStore.Server.Entities.Models
{
    /// <summary>
    /// Represents an event.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Unique id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the event.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// When the event takes place.
        /// </summary>
        public DateTimeOffset Date { get; set; }

        /// <summary>
        /// Where the event takes place.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Price of one ticket for the event.
        /// </summary>
        public float PricePerTicket { get; set; }

        /// <summary>
        /// Maximum count of tickets available.
        /// </summary>
        public int MaxTicketCount { get; set; }

        /// <summary>
        /// Maximum count of tickets a customer can buy.
        /// </summary>
        public int MaxTicketsPerCustomer { get; set; }

        /// <summary>
        /// Sales start date.
        /// </summary>
        public DateTimeOffset SalesStartDate { get; set; }

        /// <summary>
        /// Duration of a sale.
        /// </summary>
        public TimeSpan SaleDuration { get; set; }

        /// <summary>
        /// List of tickets sold to customers.
        /// </summary>
        public IEnumerable<Dictionary<Customer, Ticket>> SoldTickets { get; set; }
    }
}
    