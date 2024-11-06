using DemoSecurity.Domain.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoSecurity.BLL.Utils
{
    public class TokenManager(IConfiguration configuration)
    {
        public string CreateToken(int id, string email, UserRole role)
        {
            var credentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                        configuration["Jwt:Key"] ?? throw new Exception("Missing JWT config")
                    )),
                SecurityAlgorithms.HmacSha256
            );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var token = handler.CreateJwtSecurityToken(
                null, 
                null, new  ClaimsIdentity([
                    new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, role.ToString()),
                ]), 
                DateTime.Now, // qd ca commence
                DateTime.Now.AddDays(3), // qd ca se termine
                DateTime.Now, // qd le token a été créé
                credentials
            );
            return handler.WriteToken(token);
        }
    }
}
