using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.AlternativesRepositories
{
    public interface IAlternativeUpdateOnlyRepository
    {
        void Update(Alternative entity);
    }
}
