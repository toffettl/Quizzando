using Quizzando.DataAccess.Repositories.UserDisciplineRepositories;

namespace Quizzando.UseCases.UserDisciplines.GetByUserIdAndDisciplineId
{
    public interface IDeleteUserDisciplineRelationUseCase
    {
        Task Execute(Guid id);
    }
}
