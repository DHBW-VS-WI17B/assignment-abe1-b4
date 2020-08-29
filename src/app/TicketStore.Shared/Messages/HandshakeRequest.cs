using System;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Immutable handshake request message.
    /// </summary>
    public class HandshakeRequest : MessageBase
    {
        /// <summary>
        /// Dispatch date.
        /// </summary>
        public DateTime DispatchDate { get; } = DateTime.UtcNow;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        public HandshakeRequest(Guid requestId) : base(requestId)
        {

        }
    }
}
