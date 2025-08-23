namespace Quizzando.DataAccess.Repositories.UserRepositories
{
    public interface IUserReadOnlyRepository
    {
        Task<bool> ExistActiveUserWithEmail(string email);
    }
}
