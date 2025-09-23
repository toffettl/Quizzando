using Microsoft.EntityFrameworkCore;
using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.UserDisciplineRepositories
{
    public class UserDisciplineRelationRepository : 
        IUserDisciplineRelationWriteOnlyRepository,
        IUserDisciplineRelationReadOnlyRepository
    {
        private readonly QuizzandoDbContext _dbContext;

        public UserDisciplineRelationRepository(
            QuizzandoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(UserDisciplineRelation userDiscipline)
        {
            await _dbContext.UserDisciplineRelation
                .AddAsync(userDiscipline);
        }

        public async Task<bool?> Delete(Guid id)
        {
            var result = await _dbContext.UserDisciplineRelation.FirstOrDefaultAsync(udr => udr.Id == id);

            if (result == null)
            {
                return false;
            }

            _dbContext.UserDisciplineRelation.Remove(result);

            return true;
        }

        public async Task<bool> ExistsWithUserIdAndDisciplineId(Guid userId, Guid disciplineId)
        {
            return await _dbContext.UserDisciplineRelation
                .AnyAsync(user => user.UserId == userId && user.DisciplineId == disciplineId);
        }

        public async Task<List<UserDisciplineRelation>> GetUserDisciplineRelationsByDisciplineId(Guid disciplineId)
        {
            return await _dbContext.UserDisciplineRelation
                .Where(udr => udr.DisciplineId == disciplineId)
                .ToListAsync();
        }

        public async Task<List<UserDisciplineRelation>> GetUserDisciplineRelationsByUserId(Guid userId)
        {
            return await _dbContext.UserDisciplineRelation
                .Where(udr => udr.UserId == userId)
                .ToListAsync();
        }
    }
}
