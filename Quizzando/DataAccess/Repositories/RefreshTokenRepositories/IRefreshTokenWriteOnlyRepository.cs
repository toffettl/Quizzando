using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.RefreshTokenRepositories
{
    public interface IRefreshTokenWriteOnlyRepository
    {
        Task Add(RefreshToken token);
        Task Invalidate(RefreshToken token);
    }
}