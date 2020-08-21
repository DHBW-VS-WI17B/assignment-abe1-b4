using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Models
{
    public class TicketDto
    {
        /// <summary>
        /// Unique id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// When the ticket was purchased
        /// </summary>
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// Event id foreign key.
        /// </summary>
        public Guid EventId { get; set; }

        /// <summary>
        /// User id foreign key.
        /// </summary>
        public Guid UserId { get; set; }

        public TicketDto(Guid id, DateTime purchaseDate, Guid eventId, Guid userId)
        {
            Id = id;
            PurchaseDate = purchaseDate;
            EventId = eventId;
            UserId = userId;
        }
    }
}
