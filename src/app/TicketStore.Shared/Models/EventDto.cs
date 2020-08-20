﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Models
{
    public class EventDto
    {
        /// <summary>
        /// Unique id.
        /// </summary>
        public Guid? Id { get; }

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
        public DateTime SalesStartDate { get; }

        /// <summary>
        /// Duration of a sale.
        /// </summary>
        public TimeSpan SaleDuration { get; }

        public EventDto(
            Guid id,
            string name,
            DateTime date,
            string location,
            double pricePerTicket,
            int maxTicketCount,
            int maxTicketsPerUser,
            DateTime salesStartDate,
            TimeSpan saleDuration
            )
        {
            Id = id;
            Name = name;
            Date = date;
            Location = location;
            PricePerTicket = pricePerTicket;
            MaxTicketCount = maxTicketCount;
            MaxTicketsPerUser = maxTicketsPerUser;
            SalesStartDate = salesStartDate;
            SaleDuration = saleDuration;
        }

        public EventDto(
            string name,
            DateTime date,
            string location,
            double pricePerTicket,
            int maxTicketCount,
            int maxTicketsPerUser,
            DateTime salesStartDate,
            TimeSpan saleDuration
            )
        {
            Name = name;
            Date = date;
            Location = location;
            PricePerTicket = pricePerTicket;
            MaxTicketCount = maxTicketCount;
            MaxTicketsPerUser = maxTicketsPerUser;
            SalesStartDate = salesStartDate;
            SaleDuration = saleDuration;
        }
    }
}