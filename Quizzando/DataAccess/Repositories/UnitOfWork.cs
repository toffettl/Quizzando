namespace Quizzando.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuizzandoDbContext _dbContext;
        public UnitOfWork(QuizzandoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Commit() => await _dbContext.SaveChangesAsync();
    }
}
