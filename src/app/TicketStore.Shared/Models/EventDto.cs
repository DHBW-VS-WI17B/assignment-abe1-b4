using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Models
{
    /// <summary>
    /// Event data transfer object.
    /// </summary>
    public class EventDto
    {
        /// <summary>
        /// Unique id.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Name of the event.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// When the event takes place.
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// Where the event takes place.
        /// </summary>
        public string Location { get; }

        /// <summary>
        /// Price of one ticket for the event.
        /// </summary>
        public double PricePerTicket { get; }

        /// <summary>
        /// Maximum count of tickets available.
        /// </summary>
        public int MaxTicketCount { get; }

        /// <summary>
        /// Maximum count of tickets a user can buy.
        /// </summary>
        public int MaxTicketsPerUser { get; }

        /// <summary>
        /// Sales start date.
        /// </summary>
        public DateTime SaleStartDate { get; }

        /// <summary>
        /// Sale end date.
        /// </summary>
        public DateTime SaleEndDate { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">Event id.</param>
        /// <param name="name">Name of the event.</param>
        /// <param name="date">When the event takes place.</param>
        /// <param name="location">Where the event takes place.</param>
        /// <param name="pricePerTicket">Price of one ticket for the event.</param>
        /// <param name="maxTicketCount">Maximum count of tickets available.</param>
        /// <param name="maxTicketsPerUser">Maximum count of tickets a user can buy.</param>
        /// <param name="saleStartDate">Sales start date.</param>
        /// <param name="saleEndDate">Sale end date.</param>
        public EventDto(
            Guid id,
            string name,
            DateTime date,
            string location,
            double pricePerTicket,
            int maxTicketCount,
            int maxTicketsPerUser,
            DateTime saleStartDate,
            DateTime saleEndDate
            )
        {
            Id = id;
            Name = name;
            Date = date;
            Location = location;
            PricePerTicket = pricePerTicket;
            MaxTicketCount = maxTicketCount;
            MaxTicketsPerUser = maxTicketsPerUser;
            SaleStartDate = saleStartDate;
            SaleEndDate = saleEndDate;
        }
    }
}
