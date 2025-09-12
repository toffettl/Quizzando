using Microsoft.EntityFrameworkCore;
using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.AlternativesRepositories
{
    public class AlternativeRepository : IAlternativeWriteOnlyRepository, IAlternativeReadOnlyRepository, IAlternativeUpdateOnlyRepository
    {
        private readonly QuizzandoDbContext _dbContext;

        public AlternativeRepository(
            QuizzandoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Alternative alternative)
        {
            await _dbContext.Alternative.AddAsync(alternative);
        }

        public async Task<bool?> Delete(Guid id)
        {
            var result = await _dbContext.Alternative.FirstOrDefaultAsync(alternative => alternative.Id == id);

            if (result == null)
            {
                return false;
            }

            _dbContext.Alternative.Remove(result);

            return true;
        }

        public async Task<List<Alternative>> GetAll()
        {
            return await _dbContext.Alternative.AsNoTracking().ToListAsync();
        }

        public async Task<Alternative?> GetById(Guid id)
        {
            return await _dbContext.Alternative.AsNoTracking().FirstOrDefaultAsync(alternative => alternative.Id == id);
        }

        public Task<List<Alternative>> GetByQuestionId(Guid questionId)
        {
            return _dbContext.Alternative.AsNoTracking().Where(a => a.QuestionId == questionId).ToListAsync();
        }

        public void Update(Alternative entity)
        {
            _dbContext.Alternative.Update(entity);
        }
    }
}
