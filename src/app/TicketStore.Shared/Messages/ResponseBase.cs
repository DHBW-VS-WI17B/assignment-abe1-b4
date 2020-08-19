using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Base response.
    /// </summary>
    public abstract class ResponseBase
    {
        /// <summary>
        /// Indicates a successful operation.
        /// </summary>
        public bool IsSuccess { get; } = true;

        /// <summary>
        /// Error Message.
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Default constructor for successfull responses.
        /// </summary>
        public ResponseBase() {}

        /// <summary>
        /// Constructor for unsuccessfull responses.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        public ResponseBase(string errorMessage)
        {
            IsSuccess = false;
            ErrorMessage = errorMessage;
        }
    }
}
