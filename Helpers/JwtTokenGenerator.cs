using Microsoft.IdentityModel.Tokens;
using Reliable_Reservations.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Reliable_Reservations.Helpers
{
    public static class JwtTokenGenerator
    {
        public static string GenerateJwtToken(Admin user, IConfiguration configuration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            var issuer = configuration["Jwt:Issuer"];
            var audience = configuration["Jwt:Audience"];

            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, "Admin"), // Not used, may implement later
                new Claim(ClaimTypes.Email, user.Email),
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
