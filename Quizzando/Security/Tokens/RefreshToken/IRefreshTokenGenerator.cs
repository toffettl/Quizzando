using Quizzando.Models;

namespace Quizzando.Security.Tokens.RefreshToken
{
    public interface IRefreshTokenGenerator
    {
        string Generate(User user);

    }
}
