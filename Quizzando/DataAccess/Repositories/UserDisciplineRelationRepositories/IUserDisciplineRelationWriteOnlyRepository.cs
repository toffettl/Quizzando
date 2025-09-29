using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.UserDisciplineRepositories
{
    public interface IUserDisciplineRelationWriteOnlyRepository
    {
        Task Add(UserDisciplineRelation userDiscipline);
        Task<bool?> Delete(Guid id);
    }
}
