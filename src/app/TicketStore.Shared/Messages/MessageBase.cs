using System;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Immutable message base class.
    /// </summary>
    public abstract class MessageBase
    {
        /// <summary>
        /// Request id.
        /// Used to track requests through the actor systems.
        /// </summary>
        public Guid RequestId { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        public MessageBase(Guid requestId)
        {
            RequestId = requestId;
        }
    }
}
