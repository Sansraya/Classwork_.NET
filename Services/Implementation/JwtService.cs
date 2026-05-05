using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Sem2.Services.Implementation
{
    public class JwtService
    {
        public string GenerateToken()
        {
            var secretKey= "my_secret_key_12345";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenObj = new JwtSecurityToken(
                issuer: "Sansraya",
                audience: "React",
                claims: [],
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(1)
                );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenObj);
            return token;
        }
    }
}
