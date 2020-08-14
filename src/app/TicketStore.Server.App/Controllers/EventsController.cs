using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TicketStore.Server.App.Extensions;
using TicketStore.Server.App.Resources;

namespace TicketStore.Server.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Create, read, update and delete events and more.")]
    public class EventsController : ControllerBase
    {
        /// <summary>
        /// Get all events.
        /// </summary>
        /// <returns>List of all events.</returns>
        [HttpGet]
        [Route("")]
        [Authorize]
        [SwaggerResponse(200, "Returned all events.")]
        [SwaggerResponse(401, "Jwt authorization failed.")]
        public async Task<ActionResult<IEnumerable<EventResource>>> GetAllEventsAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates an event.
        /// Only available for admins.
        /// </summary>
        /// <param name="createEventResource">Details of the event to be created.</param>
        /// <returns>Created event resource.</returns>
        [HttpPost]
        [Route("")]
        [Authorize(Roles = "admin")]
        [SwaggerResponse(401, "Jwt authorization failed.")]
        [SwaggerResponse(201, "Event created.")]
        [SwaggerResponse(400, "The event data is invalid.", typeof(List<string>))]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<EventResource>> CreateEventAsync([FromBody] CreateEventResource createEventResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an event by id.
        /// </summary>
        /// <param name="eventId">Event id.</param>
        /// <returns>Event resource.</returns>
        [HttpGet]
        [Route("{eventId}")]
        [Authorize]
        [SwaggerResponse(401, "Jwt authorization failed.")]
        [SwaggerResponse(200, "Event returned.")]
        [SwaggerResponse(404, "Event not found.")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<EventResource>> GetEventAsync([FromRoute] Guid eventId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an event.
        /// </summary>
        /// <param name="eventId">Event id.</param>
        /// <param name="updateEventResource">Event resource.</param>
        /// <returns>Updated event resource.</returns>
        [HttpPut]
        [Route("{eventId}")]
        [Authorize(Roles = "admin")]
        [SwaggerResponse(401, "Jwt authorization failed.")]
        [SwaggerResponse(400, "The event data is invalid.", typeof(List<string>))]
        [SwaggerResponse(200, "Event updated.")]
        [SwaggerResponse(404, "Event not found.")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<EventResource>> UpdateEventAsync([FromRoute] Guid eventId, [FromBody] UpdateEventResource updateEventResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes an event.
        /// </summary>
        /// <param name="eventId">Event id.</param>
        /// <returns>Deleted event resource.</returns>
        [HttpDelete]
        [Route("{eventId}")]
        [Authorize(Roles = "admin")]
        [SwaggerResponse(401, "Jwt authorization failed.")]
        [SwaggerResponse(200, "Event deleted.")]
        [SwaggerResponse(404, "Event not found.")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<EventResource>> DeleteEventAsync([FromRoute] Guid eventId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the sold tickets for given event.
        /// Only available for admins.
        /// </summary>
        /// <param name="eventId">Event id.</param>
        /// <returns>Sold ticket resources.</returns>
        [HttpGet]
        [Route("{eventId}/sales")]
        [Authorize(Roles = "admin")]
        [SwaggerResponse(401, "Jwt authorization failed.")]
        [SwaggerResponse(404, "Event not found.")]
        [SwaggerResponse(200, "Tickets returned.")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<IEnumerable<TicketResource>>> GetSoldTicketsAsync([FromRoute] Guid eventId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Purchase tickets.
        /// </summary>
        /// <param name="eventId">Event id.</param>
        /// <param name="count">Count of tickets.</param>
        /// <returns>Ticket resource..</returns>
        [HttpPost]
        [Route("{eventId}/purchase")]
        [Authorize]
        [SwaggerResponse(401, "Jwt authorization failed.")]
        [SwaggerResponse(404, "Event not found.")]
        [SwaggerResponse(403, "Not enough tickets left.")]
        [SwaggerResponse(409, "Remaining budget is too small.")]
        [SwaggerResponse(200, "Tickets returned.")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<TicketResource>> PurchaseTicketAsync([FromRoute] Guid eventId, [FromQuery] int count)
        {
            throw new NotImplementedException();
        }
    }
}
