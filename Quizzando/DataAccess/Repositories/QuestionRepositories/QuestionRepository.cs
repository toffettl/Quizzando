using Microsoft.EntityFrameworkCore;
using Quizzando.Models;
using System.Reflection.Metadata.Ecma335;

namespace Quizzando.DataAccess.Repositories.QuestionRepositories
{
    public class QuestionRepository: IQuestionWriteOnlyRepository, IQuestionReadOnlyRepository, IQuestionUpdateOnlyRepository
    {
        private readonly QuizzandoDbContext _dbContext;
        public QuestionRepository(QuizzandoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Question question)
        {
            await _dbContext.question.AddAsync(question);
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _dbContext.question.FirstOrDefaultAsync(q => q.id == id);

            if (result == null)
            {
                return false;
            }

            _dbContext.question.Remove(result);

            return true;
        }

        public async Task<List<Question>> GetAll()
        {
            return await _dbContext.question.AsNoTracking().ToListAsync();
        }

        public async Task<Question?> GetById(Guid id)
        {
            return await _dbContext.question.AsNoTracking().FirstOrDefaultAsync(q => q.id == id);
        }

        public void Update(Question question)
        {
            _dbContext.question.Update(question);
        }
        
        
    }
}
