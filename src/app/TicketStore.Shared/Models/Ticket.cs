using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Models
{
    /// <summary>
    /// Ticket for a happening.
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// Unique id.
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// When the ticket was purchased
        /// </summary>
        public DateTimeOffset PurchaseDate { get; } = DateTimeOffset.UtcNow;

        /// <summary>
        /// Happening id.
        /// </summary>
        public Guid HappeningId { get; }

        /// <summary>
        /// User id.
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// Constructur.
        /// </summary>
        /// <param name="happeningId">Happening id.</param>
        /// <param name="userId">User id.</param>
        public Ticket(Guid happeningId, Guid userId)
        {
            HappeningId = happeningId;
            UserId = userId;
        }
    }
}
