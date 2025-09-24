using Quizzando.Models;

namespace Quizzando.Security.Tokens.AccessToken
{
    public interface IAccessTokenGenerator
    {
        string Generate(User user);
    }
}
