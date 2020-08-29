using System;

namespace TicketStore.Server.Logic.Messages.Responses
{
    /// <summary>
    /// Immutable response message base class.
    /// </summary>
    public abstract class ResponseBase
    {
        /// <summary>
        /// Request id.
        /// </summary>
        public Guid RequestId { get; }

        /// <summary>
        /// Indicates the success of the requested operation.
        /// </summary>
        public bool Successful { get; }

        /// <summary>
        /// Error message.
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="errorMessage">Error message.</param>
        public ResponseBase(Guid requestId, string errorMessage = null)
        {
            RequestId = requestId;
            ErrorMessage = errorMessage;

            if (errorMessage == null)
            {
                Successful = true;
            }
        }
    }
}
