using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Models
{
    /// <summary>
    /// Ticket data transfer object with the related event.
    /// </summary>
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

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">Ticket id.</param>
        /// <param name="purchaseDate">Purchase date.</param>
        /// <param name="userId">User id.</param>
        /// <param name="eventDto">Event data transfer object.</param>
        public RichTicketDto(Guid id, DateTime purchaseDate, Guid userId, EventDto eventDto)
        {
            Id = id;
            PurchaseDate = purchaseDate;
            UserId = userId;
            EventDto = eventDto;
        }
    }
}
