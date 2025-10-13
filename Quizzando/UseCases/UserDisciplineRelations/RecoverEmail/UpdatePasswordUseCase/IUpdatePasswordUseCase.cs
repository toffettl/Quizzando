using Quizzando.Communication.Requests.User;

namespace Quizzando.UseCases.UserDisciplineRelations.RecoverEmail.UpdatePasswordUseCase;

public interface IUpdatePasswordUseCase
{
    Task Execute(Guid userId, string newPassword);
}
