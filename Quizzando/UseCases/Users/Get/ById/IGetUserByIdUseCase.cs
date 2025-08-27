using Quizzando.Communication.Responses.User;

namespace Quizzando.UseCases.Users.Get.ById
{
    public interface IGetUserByIdUseCase
    {
        Task<UserGetByIdResponse> Execute(Guid id);
    }
}
