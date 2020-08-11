using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketStore.Server.Entities;

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
        public async Task<IActionResult> GetEvents()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an event by id.
        /// </summary>
        /// <param name="eventId">Event id.</param>
        /// <returns>Event with all details.</returns>
        [HttpGet]
        [Route("{eventId}")]
        public async Task<IActionResult> GetEventById(Guid eventId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the number of sold tickets for given event.
        /// Only available for admins.
        /// </summary>
        /// <param name="eventId">Event id.</param>
        /// <returns>Number of sold tickets for this event.</returns>
        [HttpGet]
        [Route("{eventId}/sales")]
        public async Task<IActionResult> GetNumberOfSales(Guid eventId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates an event.
        /// Only available for admins.
        /// </summary>
        /// <param name="eventBody">Details of the event to be created.</param>
        /// <returns>Id of the created event.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] Event eventBody)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Only available for customers.
        /// </summary>
        /// <param name="eventId">Event id.</param>
        /// <param name="count">Count of tickets.</param>
        /// <returns>Ticket id.</returns>
        [HttpPost]
        [Route("{eventId}/purchase")]
        public async Task<IActionResult> PurchaseTicket(Guid eventId, [FromQuery] int count)
        {
            throw new NotImplementedException();
        }
    }
}
