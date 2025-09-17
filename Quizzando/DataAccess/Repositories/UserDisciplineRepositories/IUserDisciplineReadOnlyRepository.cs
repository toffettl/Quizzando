using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.UserDisciplineRepositories
{
    public interface IUserDisciplineReadOnlyRepository
    {
        Task<bool> ExistsWithUserIdAndDisciplineId(Guid userId, Guid disciplineId);
    }
}
