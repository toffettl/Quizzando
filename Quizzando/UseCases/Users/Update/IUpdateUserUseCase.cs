using Quizzando.Communication.Requests.User;

namespace Quizzando.UseCases.Users.Update
{
    public interface IUpdateUserUseCase
    {
        Task Execute(Guid id, UserUpdateRequest userUpdateRequest);
    }
}
