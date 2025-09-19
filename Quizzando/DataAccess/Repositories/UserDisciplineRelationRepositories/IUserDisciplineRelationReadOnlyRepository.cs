using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.UserDisciplineRepositories
{
    public interface IUserDisciplineRelationReadOnlyRepository
    {
        Task<bool> ExistsWithUserIdAndDisciplineId(Guid userId, Guid disciplineId);
    }
}
