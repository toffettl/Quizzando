using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.DisciplineRepositories
{
    public interface IDisciplineUpdateOnlyRepository
    {
        void Update(Discipline entity);
    }
}
