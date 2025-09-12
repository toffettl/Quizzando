using Quizzando.Communication.Requests.Authentication;
using Quizzando.Communication.Responses.Authentication;

namespace Quizzando.UseCases.Authentication.Register
{
    public interface IRegisterUserUseCase
    { 
      
        Task<UserRegisterResponse> Execute(UserRegisterRequest request);
    }
}
