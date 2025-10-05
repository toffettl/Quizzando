using Quizzando.Communication.Requests.Course;
using Quizzando.Communication.Responses.Course;

namespace Quizzando.UseCases.Courses.Update
{
    public interface IUpdateCourseUseCase
    {
        Task Execute(Guid id, UpdateCourseRequest request);
    }
}