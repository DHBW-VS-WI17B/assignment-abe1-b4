using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Messages
{
    public class GetAllEventsRequest : MessageBase
    {
        public GetAllEventsRequest(Guid requestId) : base(requestId)
        {

        }
    }
}
