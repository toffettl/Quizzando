using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.DisciplineRepositories
{
    public interface IDisciplineReadOnlyRepository
    {
        Task<Discipline?> GetById(Guid id);
        Task<List<Discipline>> GetAll();
        Task<List<Discipline>> GetByCourseId(Guid courseId);
    }
}
