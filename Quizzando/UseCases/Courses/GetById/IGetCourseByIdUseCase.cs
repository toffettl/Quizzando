using Quizzando.Communication.Responses.Course;

namespace Quizzando.UseCases.Courses.GetById
{
    public interface IGetCourseByIdUseCase
    {
        Task<CourseResponseJson> Execute(Guid id);
    }
}