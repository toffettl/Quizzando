using Microsoft.IdentityModel.Tokens;
using Quizzando.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Quizzando.Security.Tokens
{
    public class JwtRefreshTokenGenerator : IRefreshTokenGenerator
    {
        private readonly uint _refreshTokenExpirationTime;
        private readonly string _signingKey;

        public JwtRefreshTokenGenerator(uint refreshTokenExpirationTime, string signingKey)
        {
            _refreshTokenExpirationTime = refreshTokenExpirationTime;
            _signingKey = signingKey;
        }
        public string Generator(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Sid, user.Id.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(_refreshTokenExpirationTime),
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private SymmetricSecurityKey SecurityKey()
        {
            var key = Encoding.UTF8.GetBytes(_signingKey);

            return new SymmetricSecurityKey(key);
        }
    }
}
