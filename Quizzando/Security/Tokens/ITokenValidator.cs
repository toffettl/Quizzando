using System.Security.Claims;

namespace Quizzando.Security.Tokens
{
    public interface ITokenValidator
    {
        ClaimsPrincipal Validate(string token);
    }
}
