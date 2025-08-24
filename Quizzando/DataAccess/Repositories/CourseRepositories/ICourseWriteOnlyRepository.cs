using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.CourseRepositories
{
    public interface ICourseWriteOnlyRepository
    {
        Task Add(Course course);
        Task Update(Course course);
        Task Delete(Course course);
    }
}