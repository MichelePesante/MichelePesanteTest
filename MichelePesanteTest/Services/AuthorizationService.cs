using MichelePesanteTest.Entities;
using MichelePesanteTest.Interfaces;
using MichelePesanteTest.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MichelePesanteTest.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly SecuritySettings securitySettings;

        public AuthorizationService(IOptions<SecuritySettings> _securitySettings)
        {
            securitySettings = _securitySettings.Value;
        }

        public User Authenticate(string login, string secret)
        {
            // Retrieving all secrets
            List<string> secrets = securitySettings.Credentials.Split(",").ToList();

            try
            {
                // Retrieving secret through name
                var secretCheck = secrets.Where(s => s.Split(":")[0] == login).Select(e => e.Split(":")[1]).First();

                if (secretCheck == secret)
                {
                    // Generating token
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(securitySettings.Secret);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, login),
                        }),
                        Expires = DateTime.UtcNow.AddMinutes(securitySettings.ExpirationTokenMinutes),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    // Gets user data
                    return new User()
                    {
                        ID = login.Split("_")[1],
                        Name = login.Split("_")[0],
                        Token = tokenHandler.WriteToken(token)
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GetUser(string encryptedToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jsonToken = tokenHandler.ReadJwtToken(encryptedToken);
            var user = jsonToken.Claims.FirstOrDefault(claim => ClaimTypes.Name != null).Value;
            return user;
        }
    }
}
