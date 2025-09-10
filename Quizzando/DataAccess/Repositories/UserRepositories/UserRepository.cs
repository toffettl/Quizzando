using Microsoft.EntityFrameworkCore;
using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.UserRepositories
{
    public class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository, IUserUpdateOnlyRepository
    {
        private readonly QuizzandoDbContext _dbContext;
        public UserRepository(QuizzandoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(User user)
        {
            await _dbContext.user.AddAsync(user);
        }

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _dbContext.user.AnyAsync(user => user.email!.Equals(email));
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _dbContext.user.FirstAsync(user => user.id == id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.user.AsNoTracking().ToListAsync();
        }

        public async Task<bool?> Delete(Guid id)
        {
            var result = await _dbContext.user.FirstOrDefaultAsync(user => user.id == id);

            if (result == null)
            {
                return false;
            }

            _dbContext.user.Remove(result);

            return true;
        }

        public void Update(User user)
        {
            _dbContext.user.Update(user);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _dbContext.user.AsNoTracking().FirstOrDefaultAsync(user => user.email!.Equals(email));
        }
    }
}
