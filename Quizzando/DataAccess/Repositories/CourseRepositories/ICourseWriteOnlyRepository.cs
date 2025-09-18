using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.CourseRepositories
{
    public interface ICourseWriteOnlyRepository
    {
        Task Add(Course course);
        void Update(Course course);
        void Delete(Course course);
    }
}