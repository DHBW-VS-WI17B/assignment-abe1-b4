using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Immutable error message.
    /// </summary>
    public class ErrorMessage : MessageBase
    {
        /// <summary>
        /// Error message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="Message">Error message.</param>
        public ErrorMessage(Guid requestId, string message) : base(requestId)
        {
            Message = message;
        }
    }
}
