using Quizzando.Communication.Requests.User;
using Quizzando.Communication.Responses.User;

namespace Quizzando.UseCases.Users.Refresh
{
    public interface IRefreshTokenUseCase
    {
        Task<ResponseRefreshJson> Execute(RequestRefreshJson request);
    }
}
