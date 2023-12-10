using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TwiXter.Models;

namespace TwiXter.Helpers
{
    public class JWTGenerator
    {
        public static string GenerateToken(string login,string email)
        {

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, login),
                                           new Claim(ClaimTypes.Email, email)
            };
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt).ToString();
        }
    }
}
