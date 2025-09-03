using Microsoft.IdentityModel.Tokens;
using Quizzando.Models;
using Quizzando.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Quizzando.Security.Tokens
{
    public class JwtAccessTokenGenerator : IAccessTokenGenerator
    {
        private readonly uint _accessTokenExpirationTime;
        private readonly string _signingKey;

        public JwtAccessTokenGenerator(uint accessTokenExpirationTime, string signingKey)
        {
            _accessTokenExpirationTime = accessTokenExpirationTime;
            _signingKey = signingKey;
        }

        public string Generate(User user)
        {
            var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email, user.Email!),
            new Claim(ClaimTypes.Sid, user.Id.ToString())
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(_accessTokenExpirationTime),
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }

        private SymmetricSecurityKey SecurityKey()
        {
            var key = Encoding.UTF8.GetBytes(_signingKey);

            return new SymmetricSecurityKey(key);
        }
    }
}
