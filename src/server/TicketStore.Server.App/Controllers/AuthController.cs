using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketStore.Server.App.Interfaces;
using TicketStore.Server.App.Models;

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
        /// Users can register an account.
        /// </summary>
        /// <param name="registerRequest">Body of the register request.</param>
        /// <returns>User id.</returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(userId);
        }

        /// <summary>
        /// Authenticates a user.
        /// </summary>
        /// <param name="authenticateRequest">Username and password.</param>
        /// <returns>Json web token.</returns>
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Authenticate([FromBody] AuthenticateRequest authenticateRequest)
        {
            string jwt;
            try
            {
                jwt = _jwtAuthManager.Authenticate(authenticateRequest.UserName, authenticateRequest.Password);
                if (jwt == null)
                {
                    return Unauthorized();
                }
                return Ok(new AuthenticateResponse
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
