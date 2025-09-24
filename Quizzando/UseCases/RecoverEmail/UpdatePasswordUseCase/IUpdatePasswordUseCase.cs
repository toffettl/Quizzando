using Quizzando.Communication.Requests.User;

namespace Quizzando.UseCases.RecoverEmail.UpdatePasswordUseCase;

public interface IUpdatePasswordUseCase
{
    Task Execute(Guid userId, string newPassword);
}
