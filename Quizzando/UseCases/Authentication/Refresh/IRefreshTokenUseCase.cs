using Quizzando.Communication.Responses.Authentication;

namespace Quizzando.UseCases.Authentication.Refresh
{
    public interface IRefreshTokenUseCase
    {
        Task<ResponseTokenJson> Execute(string refreshToken);
    }
}