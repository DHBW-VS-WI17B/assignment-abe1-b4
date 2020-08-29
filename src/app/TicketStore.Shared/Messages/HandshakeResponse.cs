using System;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Handshake response message.
    /// </summary>
    public class HandshakeResponse : MessageBase
    {
        /// <summary>
        /// Dispatch date of the request.
        /// </summary>
        public DateTime RequestDispatchDate { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="requestDispatchDate">Dispatch date of the request.</param>
        public HandshakeResponse(Guid requestId, DateTime requestDispatchDate) : base(requestId)
        {
            RequestDispatchDate = requestDispatchDate;
        }
    }
}
