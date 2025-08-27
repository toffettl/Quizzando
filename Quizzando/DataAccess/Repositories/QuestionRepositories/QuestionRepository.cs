using Microsoft.EntityFrameworkCore;
using Quizzando.Models;
using System.Reflection.Metadata.Ecma335;

namespace Quizzando.DataAccess.Repositories.QuestionRepositories
{
    public class QuestionRepository: IQuestionWriteOnlyRepository, IQuestionReadOnlyRepository
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

        public async Task<List<Question>> GetAll()
        {
            return await _dbContext.Question.AsNoTracking().ToListAsync();
        }
    }
}
