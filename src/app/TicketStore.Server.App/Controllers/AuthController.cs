using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketStore.Server.App.Resources;
using TicketStore.Server.App.Interfaces;
using TicketStore.Server.App.Extensions;

namespace TicketStore.Server.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthManager _jwtAuthManager;
        public AuthController(IJwtAuthManager jwtAuthManager)
        {
            _jwtAuthManager = jwtAuthManager;
        }

        /// <summary>
        /// Authenticates a user.
        /// </summary>
        /// <param name="authRequest">Username and password.</param>
        /// <returns>Json web token.</returns>
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponseResource>> AuthenticateAsync([FromBody] AuthRequestResource authRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            string jwt;
            try
            {
                jwt = _jwtAuthManager.Authenticate(authRequest.UserName, authRequest.Password);
                if (jwt == null)
                {
                    return Unauthorized();
                }
                return Ok(new AuthResponseResource
                { 
                    Jwt = jwt
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
