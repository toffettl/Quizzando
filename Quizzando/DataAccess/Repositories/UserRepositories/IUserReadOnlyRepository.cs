using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.UserRepositories
{
    public interface IUserReadOnlyRepository
    {
        Task<bool> ExistActiveUserWithEmail(string email);
        Task<User> GetUserById(Guid id);
        Task<List<User>> GetAllUsers();
        Task<User?> GetByEmail(string email);
    }
}
