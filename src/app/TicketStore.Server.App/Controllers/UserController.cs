using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketStore.Server.App.Extensions;
using TicketStore.Server.App.Resources;

namespace TicketStore.Server.App.Controllers
{
    /// <summary>
    /// User controller.
    /// </summary>
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("")]
        public async Task<ActionResult<IEnumerable<UserResource>>> GetAllUsersAsync([FromRoute] Guid userId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("")]
        public async Task<ActionResult<UserResource>> CreateUserAsync([FromBody] CreateUserResource createUserResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<UserResource>> GetUserAsync([FromRoute] Guid userId)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("{userId}")]
        public async Task<ActionResult<UserResource>> UpdateUserAsync([FromRoute] Guid userId, [FromBody] UpdateUserResource updateUserResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            // admin or user itself
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{userId}")]
        public async Task<ActionResult<UserResource>> DeleteUserAsync([FromRoute] Guid userId)
        {
            // admin or user itself
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a list of purchased tickets.
        /// </summary>
        /// <param name="sort">Sort by either "orderDate" or "eventDate".</param>
        /// <param name="order">Order ascending ("asc") oder descending ("desc").</param>
        /// <returns>Returns a list of tickets.</returns>
        [HttpGet]
        [Route("{userId}/tickets")]
        public async Task<ActionResult<IEnumerable<TicketResource>>> GetTicketsAsync([FromRoute] Guid userId, [FromQuery] string sort, [FromQuery] string order)
        {
            var claimUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            throw new NotImplementedException();
        }


        /// <summary>
        /// Gets the budget of a user.
        /// Only available for users.
        /// </summary>
        /// <returns>Budget of a user</returns>
        [HttpGet]
        [Route("{userId}/budget")]
        public async Task<ActionResult<BudgetResource>> GetBudgetAsync([FromRoute] Guid userId)
        {
            var claimUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            throw new NotImplementedException();
        }
    }
}
