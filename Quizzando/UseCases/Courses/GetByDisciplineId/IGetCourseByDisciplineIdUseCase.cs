using Quizzando.Communication.Responses.Course;
using Quizzando.Models;

namespace Quizzando.UseCases.Courses.GetByDisciplineId
{
    public interface IGetCourseByDisciplineIdUseCase
    {
        Task<List<CourseResponseJson>> Execute(Guid disciplineId);
    }
}
