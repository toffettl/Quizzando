using Quizzando.Communication.Responses.Course;
using Quizzando.Models;

namespace Quizzando.UseCases.Courses.GetByDisciplineId
{
    public interface IGetCourseByDisciplineIdUseCase
    {
        Task<List<CourseResponse>> Execute(Guid disciplineId);
    }
}
