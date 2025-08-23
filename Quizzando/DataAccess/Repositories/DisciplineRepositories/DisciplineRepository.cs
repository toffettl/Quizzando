using Quizzando.DataAccess.Repositories.DisciplineRepository;
using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.DisciplineRepositories
{
    public class DisciplineRepository : IDisciplineWriteOnlyRepository  
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
    }
}
