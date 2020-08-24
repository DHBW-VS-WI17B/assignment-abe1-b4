using System;
using System.Collections.Generic;
using System.Text;

namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Immutable get remaining budget for current year request message.
    /// </summary>
    public class GetRemainingBudgetForCurrentYearRequest
    {
        /// <summary>
        /// User id.
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="userId">User id.</param>
        public GetRemainingBudgetForCurrentYearRequest(Guid userId)
        {
            UserId = userId;
        }
    }
}
