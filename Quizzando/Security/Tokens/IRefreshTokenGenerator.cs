using Quizzando.Models;

namespace Quizzando.Security.Tokens
{
    public interface IRefreshTokenGenerator
    {
        string Generator(User user);
    }
}
