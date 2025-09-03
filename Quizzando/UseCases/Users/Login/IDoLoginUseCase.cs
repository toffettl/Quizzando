using Quizzando.Communication.Requests.User;
using Quizzando.Communication.Responses.User;
using Quizzando.Models;

namespace Quizzando.UseCases.Users.Login
{
    public interface IDoLoginUseCase
    {
        Task<ResponseTokenJson> Execute(RequestLoginJson request);
    }
}
