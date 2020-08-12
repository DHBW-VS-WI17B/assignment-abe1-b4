using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TicketStore.Server.App.Controllers
{
    /// <summary>
    /// User controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Gets a list of purchased tickets.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="sort">Sort by either "orderDate" or "eventDate".</param>
        /// <param name="order">Order ascending ("asc") oder descending ("desc").</param>
        /// <returns>Returns a list of tickets.</returns>
        [HttpGet]
        [Route("{userId}/tickets")]
        public async Task<IActionResult> GetTickets(Guid userId, [FromQuery] string sort, [FromQuery] string order)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Gets the budget of a user.
        /// Only available for users.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <returns>Budget of a user</returns>
        [HttpGet]
        [Route("{userId}/budget")]
        public async Task<IActionResult> GetBudget(Guid userId)
        {
            throw new NotImplementedException();
        }

    }
}
