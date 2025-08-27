using Quizzando.Communication.Responses.User;

namespace Quizzando.UseCases.Users.Get.All
{
    public interface IGetAllUsersUseCase
    {
        Task<UserGetAllResponse> Execute();
    }
}
