using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.DisciplineRepositories
{
    public interface IDisciplineReadOnlyRepository
    {
        Task<List<Discipline>> GetAll();
        Task<Discipline?> GetById(Guid id);
    }
}
