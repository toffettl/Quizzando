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
            await _dbContext.User.AddAsync(user);
        }

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _dbContext.User.AnyAsync(user => user.Email!.Equals(email));
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _dbContext.User.FirstAsync(user => user.Id == id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.User.AsNoTracking().ToListAsync();
        }

        public async Task<bool?> Delete(Guid id)
        {
            var result = await _dbContext.User.FirstOrDefaultAsync(user => user.Id == id);

            if (result == null)
            {
                return false;
            }

            _dbContext.User.Remove(result);

            return true;
        }

        public void Update(User user)
        {
            _dbContext.User.Update(user);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _dbContext.User.AsNoTracking().FirstOrDefaultAsync(user => user.Email!.Equals(email));
        }
    }
}
