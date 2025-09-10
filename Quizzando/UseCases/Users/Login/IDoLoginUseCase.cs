using Quizzando.Communication.Requests.Authentication;
using Quizzando.Communication.Responses.Authentication;
using Quizzando.Models;

namespace Quizzando.UseCases.Users.Login
{
    public interface IDoLoginUseCase
    {
        Task<ResponseTokenJson> Execute(RequestLoginJson request);
    }
}
