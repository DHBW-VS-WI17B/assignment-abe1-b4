using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketStore.Server.App.Extensions;
using TicketStore.Server.App.Resources;

namespace TicketStore.Server.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        /// <summary>
        /// Get events.
        /// </summary>
        /// <returns>List of available events as eventId and eventName.</returns>
        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<EventResource>>> GetAllEventsAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates an event.
        /// Only available for admins.
        /// </summary>
        /// <param name="createEventResource">Details of the event to be created.</param>
        /// <returns>Id of the created event.</returns>
        [HttpPost]
        [Route("")]
        [Authorize(Roles = "admin")]
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
        /// <returns>Event with all details.</returns>
        [HttpGet]
        [Route("{eventId}")]
        [Authorize]
        public async Task<ActionResult<EventResource>> GetEventAsync([FromRoute] Guid eventId)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("{eventId}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<EventResource>> UpdateEventAsync([FromRoute] Guid eventId, [FromBody] UpdateEventResource updateEventResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{eventId}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<EventResource>> DeleteEventAsync([FromRoute] Guid eventId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the sold tickets for given event.
        /// Only available for admins.
        /// </summary>
        /// <param name="eventId">Event id.</param>
        /// <returns>Number of sold tickets for this event.</returns>
        [HttpGet]
        [Route("{eventId}/sales")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<TicketResource>>> GetSoldTicketsAsync([FromRoute] Guid eventId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Only available for users.
        /// </summary>
        /// <param name="eventId">Event id.</param>
        /// <param name="count">Count of tickets.</param>
        /// <returns>Ticket id.</returns>
        [HttpPost]
        [Route("{eventId}/purchase")]
        [Authorize]
        public async Task<ActionResult<TicketResource>> PurchaseTicketAsync([FromRoute] Guid eventId, [FromQuery] int count)
        {
            throw new NotImplementedException();
        }
    }
}
