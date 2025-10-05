using Quizzando.Communication.Responses.Course;
using Quizzando.Models;

namespace Quizzando.UseCases.Courses.GetById
{
    public interface IGetCourseByIdUseCase
    {
        Task<CourseResponse> Execute(Guid id);
    }
}