using Quizzando.Communication.Responses.User;

namespace Quizzando.UseCases.Users.GetById
{
    public interface IGetUserByIdUseCase
    {
        Task<UserGetByIdResponse> Execute(Guid id);
    }
}
