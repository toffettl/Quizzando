using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.UserDisciplineRepositories
{
    public interface IUserDisciplineWriteOnlyRepository
    {
        Task Add(UserDiscipline userDiscipline);
    }
}
