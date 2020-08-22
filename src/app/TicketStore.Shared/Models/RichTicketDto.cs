using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Models
{
    public class RichTicketDto
    {
        /// <summary>
        /// Unique id.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// When the ticket was purchased
        /// </summary>
        public DateTime PurchaseDate { get; }

        /// <summary>
        /// The event.
        /// </summary>
        public EventDto EventDto { get; }

        /// <summary>
        /// User id foreign key.
        /// </summary>
        public Guid UserId { get; }

        public RichTicketDto(Guid id, DateTime purchaseDate, Guid userId, EventDto eventDto)
        {
            Id = id;
            PurchaseDate = purchaseDate;
            UserId = userId;
            EventDto = eventDto;
        }
    }
}
