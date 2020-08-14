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
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace TicketStore.Server.App.Controllers
{
    /// <summary>
    /// Authentication controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Authenticate a user.")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthManager _jwtAuthManager;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="jwtAuthManager">Json web token authentiation manager.</param>
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
        [SwaggerResponse(400, "The authentication data is invalid.", typeof(List<string>))]
        [SwaggerResponse(401, "Username or password is wrong.", typeof(List<string>))]
        [SwaggerResponse(200, "Json web token generated.")]
        [Consumes(MediaTypeNames.Application.Json)]
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
                return Unauthorized(new List<string>() { ex.Message });
            }
        }
    }
}
