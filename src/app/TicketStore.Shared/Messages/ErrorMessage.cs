using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Messages
{
    public class ErrorMessage : MessageBase
    {
        public string ErrMessage { get; }

        public ErrorMessage(Guid requestId, string errorMessage) : base(requestId)
        {
            ErrMessage = errorMessage;
        }
    }
}
