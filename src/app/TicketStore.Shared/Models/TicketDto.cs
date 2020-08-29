using System;

namespace TicketStore.Shared.Models
{
    /// <summary>
    /// Ticket data transfer object.
    /// </summary>
    public class TicketDto
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
        /// Event id foreign key.
        /// </summary>
        public Guid EventId { get; }

        /// <summary>
        /// User id foreign key.
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">Ticket id.</param>
        /// <param name="purchaseDate">Purchase date.</param>
        /// <param name="eventId">Event id.</param>
        /// <param name="userId">User id.</param>
        public TicketDto(Guid id, DateTime purchaseDate, Guid eventId, Guid userId)
        {
            Id = id;
            PurchaseDate = purchaseDate;
            EventId = eventId;
            UserId = userId;
        }
    }
}
