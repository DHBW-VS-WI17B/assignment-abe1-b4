using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicketStore.Server.App.Interfaces;
using TicketStore.Server.App.Configs;

namespace TicketStore.Server.App.Auth
{
    /// <summary>
    /// Handles json web token authentication.
    /// </summary>
    public class JwtAuthManager : IJwtAuthManager
    {
        private readonly string _key;

        public JwtAuthManager(IOptions<JwtConfig> jwtConfig)
        {
               _key = jwtConfig.Value.Secret; 
        }
        public string Authenticate(string username, string password)
        {
            // TODO: perform a real check

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKeyBytes = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()), // replace me
                    new Claim(ClaimTypes.Role, "admin") // TODO replace me
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
