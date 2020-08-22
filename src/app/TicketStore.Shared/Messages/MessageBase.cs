using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Messages
{
    public class MessageBase
    {
        public Guid RequestId { get; }

        public MessageBase(Guid requestId)
        {
            RequestId = requestId;
        }
    }
}
