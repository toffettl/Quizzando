using Quizzando.Communication.Requests.Authentication;
using Quizzando.Communication.Responses.Authentication;

namespace Quizzando.UseCases.Authentication.Login
{
    public interface IDoLoginUseCase
    {
        Task<ResponseTokenJson> Execute(RequestLoginJson request);
    }
}
