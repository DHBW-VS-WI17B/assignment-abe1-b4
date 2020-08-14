using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
    [SwaggerTag("Create, read, update and delete users and more.")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Get all users.
        /// Only available for admins.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <returns>All user resources.</returns>
        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("")]
        [SwaggerResponse(401, "Jwt authorization failed.")]
        [SwaggerResponse(200, "Returned all users.")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<IEnumerable<UserResource>>> GetAllUsersAsync([FromRoute] Guid userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="createUserResource">User resource.</param>
        /// <returns>Created user resource.</returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("")]
        [SwaggerResponse(400, "The user data is invalid.", typeof(List<string>))]
        [SwaggerResponse(403, "User already registered.")]
        [SwaggerResponse(201, "User resource created.")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<UserResource>> CreateUserAsync([FromBody] CreateUserResource createUserResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a user resource.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <returns>User resource.</returns>
        [HttpGet]
        [Route("{userId}")]
        [SwaggerResponse(401, "Jwt authorization failed.")]
        [SwaggerResponse(404, "User resource not found.")]
        [SwaggerResponse(200, "Returned user resource.")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<UserResource>> GetUserAsync([FromRoute] Guid userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update a user resource.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="updateUserResource">User resource.</param>
        /// <returns>Updated user resource.</returns>
        [HttpPut]
        [Route("{userId}")]
        [SwaggerResponse(401, "Jwt authorization failed.")]
        [SwaggerResponse(404, "User resource not found.")]
        [SwaggerResponse(400, "The user data is invalid.", typeof(List<string>))]
        [SwaggerResponse(200, "Updated user resource.")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<UserResource>> UpdateUserAsync([FromRoute] Guid userId, [FromBody] UpdateUserResource updateUserResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            // admin or user itself
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete a user.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <returns>Deleted user resource.</returns>
        [HttpDelete]
        [Route("{userId}")]
        [SwaggerResponse(401, "Jwt authorization failed.")]
        [SwaggerResponse(404, "User resource not found.")]
        [SwaggerResponse(200, "Deleted user resource.")]
        [Consumes(MediaTypeNames.Application.Json)]
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
        /// <returns>Returns a list of ticket resources.</returns>
        [HttpGet]
        [Route("{userId}/tickets")]
        [SwaggerResponse(401, "Jwt authorization failed.")]
        [SwaggerResponse(400, "Invalid sort or order query parameter.")]
        [SwaggerResponse(404, "User resource not found.")]
        [SwaggerResponse(200, "Returned ticket resources.")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<IEnumerable<TicketResource>>> GetTicketsAsync([FromRoute] Guid userId, [FromQuery] string sort, [FromQuery] string order)
        {
            var claimUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            throw new NotImplementedException();
        }


        /// <summary>
        /// Gets the budget of a user.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <returns>Budget of a user</returns>
        [HttpGet]
        [Route("{userId}/budget")]
        [SwaggerResponse(401, "Jwt authorization failed.")]
        [SwaggerResponse(404, "User resource not found.")]
        [SwaggerResponse(200, "User budget returned.")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<BudgetResource>> GetBudgetAsync([FromRoute] Guid userId)
        {
            var claimUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            throw new NotImplementedException();
        }
    }
}
