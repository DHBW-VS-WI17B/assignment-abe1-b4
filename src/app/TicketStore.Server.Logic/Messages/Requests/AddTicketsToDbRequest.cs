using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Messages;

namespace TicketStore.Server.Logic.Messages.Requests
{
    /// <summary>
    /// Immutable add ticket to db request message, including all data needed to verify if operation is valid.
    /// </summary>
    public class AddTicketsToDbRequest : MessageBase
    {
        /// <summary>
        /// Event id.
        /// </summary>
        public Guid EventId { get; }

        /// <summary>
        /// User id.
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// Ticket count.
        /// </summary>
        public int TicketCount { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="eventId">Event id.</param>
        /// <param name="userId">User id.</param>
        /// <param name="ticketCount">Ticket count.</param>
        public AddTicketsToDbRequest(Guid requestId, Guid eventId, Guid userId, int ticketCount) : base(requestId)
        {
            EventId = eventId;
            UserId = userId;
            TicketCount = ticketCount;
        }
    }

}
