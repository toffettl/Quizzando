using Microsoft.EntityFrameworkCore;
using Quizzando.DataAccess.Repositories.DisciplineRepository;
using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.DisciplineRepositories
{
    public class DisciplineRepository : IDisciplineWriteOnlyRepository, IDisciplineReadOnlyRepository  
    {
        private readonly QuizzandoDbContext _dbContext;

        public DisciplineRepository(
            QuizzandoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Discipline discipline)
        {
            await _dbContext.Discipline.AddAsync(discipline);
        }

        public async Task<List<Discipline>> GetAll()
        {
            return await _dbContext.Discipline.AsNoTracking().ToListAsync();
        }

        public async Task<Discipline?> GetById(Guid id)
        {
            return await _dbContext.Discipline.AsNoTracking().FirstOrDefaultAsync(user => user.Id == id);
        }
    }
}
