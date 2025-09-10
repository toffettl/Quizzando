using Microsoft.EntityFrameworkCore;
using Quizzando.DataAccess.Repositories.DisciplineRepository;
using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.DisciplineRepositories
{
    public class DisciplineRepository : IDisciplineWriteOnlyRepository, IDisciplineReadOnlyRepository, IDisciplineUpdateOnlyRepository
    {
        private readonly QuizzandoDbContext _dbContext;

        public DisciplineRepository(
            QuizzandoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Discipline discipline)
        {
            await _dbContext.discipline.AddAsync(discipline);
        }

        public async Task<bool?> Delete(Guid id)
        {
            var result = await _dbContext.discipline.FirstOrDefaultAsync(discipline => discipline.id == id);

            if (result == null)
            {
                return false;
            }

            _dbContext.discipline.Remove(result);

            return true;
        }

        public async Task<List<Discipline>> GetAll()
        {
            return await _dbContext.discipline.AsNoTracking().ToListAsync();
        }

        public async Task<Discipline?> GetById(Guid id)
        {
            return await _dbContext.discipline.AsNoTracking().FirstOrDefaultAsync(user => user.id == id);
        }

        public void Update(Discipline entity)
        {
            _dbContext.discipline.Update(entity);
        }
    }
}
