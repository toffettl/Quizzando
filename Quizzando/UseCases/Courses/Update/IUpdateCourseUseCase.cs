using Quizzando.Communication.Requests.Course;
using Quizzando.Communication.Responses.Course;

namespace Quizzando.UseCases.Courses.Update
{
    public interface IUpdateCourseUseCase
    {
        Task<CourseResponseJson> Execute(Guid id, UpdateCourseRequest request);
    }
}