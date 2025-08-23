namespace Quizzando.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
