namespace Quizzando.DataAccess.Repositories.AlternativesRepositories
{
    using Quizzando.Models;

    public interface IAlternativeReadOnlyRepository
    {
        Task<Alternative?> GetById(Guid id);
        Task<List<Alternative>> GetAll();
        Task<List<Alternative>> GetByQuestionId(Guid questionId);
    }
}