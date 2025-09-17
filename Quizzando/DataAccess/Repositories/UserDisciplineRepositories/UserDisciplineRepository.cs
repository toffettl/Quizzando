using Microsoft.EntityFrameworkCore;
using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.UserDisciplineRepositories
{
    public class UserDisciplineRepository : 
        IUserDisciplineWriteOnlyRepository,
        IUserDisciplineReadOnlyRepository
    {
        private readonly QuizzandoDbContext _dbContext;

        public UserDisciplineRepository(
            QuizzandoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(UserDiscipline userDiscipline)
        {
            await _dbContext.UserDiscipline
                .AddAsync(userDiscipline);
        }

        public async Task<bool> ExistsWithUserIdAndDisciplineId(Guid userId, Guid disciplineId)
        {
            return await _dbContext.UserDiscipline
                .AnyAsync(user => user.UserId == userId && user.DisciplineId == disciplineId);
        }
    }
}
