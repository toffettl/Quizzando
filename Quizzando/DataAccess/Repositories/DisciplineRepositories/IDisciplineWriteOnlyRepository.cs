using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.DisciplineRepository
{
    public interface IDisciplineWriteOnlyRepository
    {
        Task Add(Discipline discipline);
    }
}
