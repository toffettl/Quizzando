using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.RefreshTokenRepositories
{
    public interface IRefreshTokenReadOnlyRepository
    {
        Task<RefreshToken?> GetByToken(string token);
    }   
}