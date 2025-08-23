using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.CourseRepositories
{
    public interface ICourseReadOnlyRepository
    {
        Task<Course> GetCourseById(Guid id);
    }
}