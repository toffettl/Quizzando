using Quizzando.Models;

namespace Quizzando.Security.Tokens
{
    public interface IAccessTokenGenerator
    {
        string Generate(User user);
    }
}
