using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.QuestionRepositories
{
    public interface IQuestionReadOnlyRepository
    {
        Task<List<Question>> GetAll();
    }
}
