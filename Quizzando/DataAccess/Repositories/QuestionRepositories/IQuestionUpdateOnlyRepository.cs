using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.QuestionRepositories
{
    public interface IQuestionUpdateOnlyRepository
    {
        void Update(Question question);
    }
}
