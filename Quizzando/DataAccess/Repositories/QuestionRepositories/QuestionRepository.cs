using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.QuestionRepositories
{
    public class QuestionRepository: IQuestionWriteOnlyRepository
    {
        private readonly QuizzandoDbContext _dbContext;
        public QuestionRepository(QuizzandoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Question question)
        {
            await _dbContext.Question.AddAsync(question);
        }
    }
}
