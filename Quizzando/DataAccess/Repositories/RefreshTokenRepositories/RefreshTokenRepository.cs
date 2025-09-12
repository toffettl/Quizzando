using Microsoft.EntityFrameworkCore;
using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.RefreshTokenRepositories
{
    public class RefreshTokenRepository : IRefreshTokenReadOnlyRepository, IRefreshTokenWriteOnlyRepository
    {
        private readonly QuizzandoDbContext _dbContext;

        public RefreshTokenRepository(QuizzandoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<RefreshToken?> GetByToken(string token)
        {
            return await _dbContext.RefreshToken
                .FirstOrDefaultAsync(rt => rt.Token == token);
        }

        public async Task Add(RefreshToken token)
        {
            await _dbContext.RefreshToken.AddAsync(token);
        }

        public Task Invalidate(RefreshToken token)
        {
            token.IsRevoked = true;
            _dbContext.RefreshToken.Update(token);
        }
    }
}