using Quizzando.Communication.Requests.Course;
using Quizzando.Communication.Responses.Course;

namespace Quizzando.UseCases.Courses.Create
{
    public interface ICreateCourseUseCase
    {
        Task<CourseResponse> Execute(CreateCourseRequest request);
    }
}