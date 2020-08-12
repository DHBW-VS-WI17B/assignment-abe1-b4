using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketStore.Server.App.Models;

namespace TicketStore.Server.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Users can register an account.
        /// </summary>
        /// <param name="registerRequest">Body of the register request.</param>
        /// <returns>User id.</returns>
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Authenticates a user.
        /// </summary>
        /// <param name="authenticateRequest">Username and password.</param>
        /// <returns>JWT.</returns>
        [HttpGet]
        public async Task<ActionResult> Authenticate([FromBody] AuthenticateRequest authenticateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
