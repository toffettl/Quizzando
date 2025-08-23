using Microsoft.EntityFrameworkCore;
using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.UserRepositories
{
    public class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
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
    }
}
