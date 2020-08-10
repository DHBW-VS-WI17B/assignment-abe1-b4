using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TicketStore.Server.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Gets a list of purchased tickets.
        /// </summary>
        /// <param name="customerId">Customer id.</param>
        /// <param name="sort">Sort by either "orderDate" or "eventDate".</param>
        /// <param name="order">Order ascending ("asc") oder descending ("desc").</param>
        /// <returns>Returns a list of tickets.</returns>
        [HttpGet]
        [Route("/{customerId}/tickets")]
        public async Task<IActionResult> GetTickets(Guid customerId, [FromQuery] string sort, [FromQuery] string order)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Gets the budget of a customer.
        /// Only available for customers.
        /// </summary>
        /// <param name="customerId">Customer id.</param>
        /// <returns>Budget of a customer</returns>
        [HttpGet]
        [Route("/{customerId}/budget")]
        public async Task<IActionResult> GetBudget(Guid customerId)
        {
            throw new NotImplementedException();
        }

    }
}
