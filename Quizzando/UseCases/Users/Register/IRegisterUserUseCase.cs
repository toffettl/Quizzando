using Quizzando.Communication.Requests.User;
using Quizzando.Communication.Responses.User;

namespace Quizzando.UseCases.Users.Register
{
    public interface IRegisterUserUseCase
    {
        Task<UserRegisterResponse> Execute(UserRegisterRequest request);

    }
}
