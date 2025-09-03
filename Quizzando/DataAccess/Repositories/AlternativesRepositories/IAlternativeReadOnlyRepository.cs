namespace Quizzando.DataAccess.Repositories.AlternativesRepositories
{
    using Quizzando.Domain.Entities;
    public interface IAlternativeReadOnlyRepository
    {
        Task<Alternative?> GetById(Guid id);
        Task<List<Alternative>> GetAll();
        Task<List<Alternative>> GetByQuestionId(Guid questionId);
    }
}