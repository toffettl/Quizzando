using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.CourseRepositories
{
    public interface ICourseUpdateOnlyRepository
    {
        void Update(Course course);
    }
}
