using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.QuestionRepositories
{
    public interface IQuestionWriteOnlyRepository
    {
        Task Add(Question question);

        Task<bool> Delete(Guid id); 
    }
}
