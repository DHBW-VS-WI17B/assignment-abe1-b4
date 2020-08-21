using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Responses
{
    public abstract class ResponseBase
    {
        public Guid RequestId { get; }

        public bool Successful { get; } = true;

        public string ErrorMessage { get; } = string.Empty;

        public ResponseBase(Guid requestId, string errorMessage = null)
        {
            RequestId = requestId;
            ErrorMessage = errorMessage;

            if (errorMessage != null)
            {
                Successful = true;
            }
        }
    }
}
