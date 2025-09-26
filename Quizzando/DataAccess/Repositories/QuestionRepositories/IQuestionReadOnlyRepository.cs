using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.QuestionRepositories
{
    public interface IQuestionReadOnlyRepository
    {
        Task<List<Question>> GetAll();
        Task<Question?> GetById(Guid id);
        Task<List<Question>> GetByDisciplineId(Guid disciplineId);
        Task<List<Question>> GetQuiz(Guid disciplineId);
    }
}
