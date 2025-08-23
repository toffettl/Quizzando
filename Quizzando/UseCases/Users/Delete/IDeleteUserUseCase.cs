
namespace Quizzando.UseCases.Users.Delete
{
    public interface IDeleteUserUseCase
    {
        Task Execute(Guid id);
    }
}
