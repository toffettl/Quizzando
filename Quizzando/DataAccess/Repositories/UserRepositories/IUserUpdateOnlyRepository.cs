using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.UserRepositories
{
    public interface IUserUpdateOnlyRepository
    {
        void Update(User user);
    }
}
