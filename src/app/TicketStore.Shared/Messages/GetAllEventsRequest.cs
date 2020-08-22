using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Immutable get all events request message.
    /// </summary>
    public class GetAllEventsRequest : MessageBase
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        public GetAllEventsRequest(Guid requestId) : base(requestId)
        {

        }
    }
}
