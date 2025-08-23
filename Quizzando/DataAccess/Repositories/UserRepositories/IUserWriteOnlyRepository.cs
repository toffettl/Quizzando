
using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.UserRepositories
{
    public interface IUserWriteOnlyRepository
    {
        Task Add(User user);
    }
}
