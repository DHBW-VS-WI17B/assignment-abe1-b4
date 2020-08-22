using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Server.Logic.Messages.Responses
{
    public abstract class ResponseBase
    {
        public Guid RequestId { get; }

        public bool Successful { get; }

        public string ErrorMessage { get; }

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
