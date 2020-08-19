using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Requests
{
    public abstract class RequestBase
    {
        public Guid RequestId { get; } = Guid.NewGuid();
    }
}
