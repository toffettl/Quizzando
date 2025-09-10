using Microsoft.IdentityModel.Tokens;
using Quizzando.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Quizzando.Security.Tokens.RefreshToken
{
    public class RefreshTokenGenerator : IRefreshTokenGenerator
    {
        private readonly uint _expirationTimeMinutes;
        private readonly string _signingKey;
        private readonly string _issuer;
        private readonly string _audience;

        public RefreshTokenGenerator(IConfiguration configuration)
        {
            _expirationTimeMinutes = uint.Parse(configuration["Jwt:RefreshToken:ExpirationTimeMinutes"] ?? "20");
            _signingKey = configuration["Jwt:Key"];
            _issuer = configuration["Jwt:Issuer"];
            _audience = configuration["Jwt:Audience"];
        }
        public string Generate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Sid, user.Id.ToString())
            };

            var now = DateTime.UtcNow;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _issuer,
                Audience = _audience,
                NotBefore = now,
                IssuedAt = now,
                Expires = now.AddMinutes(_expirationTimeMinutes).AddSeconds(5),
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature)
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