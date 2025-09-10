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
            await _dbContext.Question.AddAsync(question);
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _dbContext.Question.FirstOrDefaultAsync(q => q.Id == id);

            if (result == null)
            {
                return false;
            }

            _dbContext.Question.Remove(result);

            return true;
        }

        public async Task<List<Question>> GetAll()
        {
            return await _dbContext.Question.AsNoTracking().ToListAsync();
        }

        public async Task<List<Question>> GetByDisciplineId(Guid disciplineId)
        {
            return await _dbContext.Question.AsNoTracking().Where(q => q.DisciplineId == disciplineId).ToListAsync();
        }

        public async Task<Question?> GetById(Guid id)
        {
            return await _dbContext.Question.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public void Update(Question question)
        {
            _dbContext.Question.Update(question);
        }
        
        
    }
}
