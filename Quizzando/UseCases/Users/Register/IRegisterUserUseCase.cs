using Quizzando.Communication.Requests.Authentication;
using Quizzando.Communication.Responses.Authentication;

namespace Quizzando.UseCases.Users.Register
{
    public interface IRegisterUserUseCase
    { 
      
        Task<UserRegisterResponse> Execute(UserRegisterRequest request);
    }
}
