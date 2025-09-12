using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.AlternativesRepositories
{
    public interface IAlternativeWriteOnlyRepository
    {
        Task Add(Alternative alternative);
        Task<bool?> Delete(Guid id);
    }
}