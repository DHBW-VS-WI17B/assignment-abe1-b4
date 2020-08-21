using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Messages
{
    public class ErrorMessage : MessageBase
    {
        public string Error { get; }

        public ErrorMessage(Guid requestId, string errorMessage) : base(requestId)
        {
            Error = errorMessage;
        }
    }
}
