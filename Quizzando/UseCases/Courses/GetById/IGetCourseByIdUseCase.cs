using Quizzando.Communication.Responses.Course;
using Quizzando.Models;

namespace Quizzando.UseCases.Courses.GetById
{
    public interface IGetCourseByIdUseCase
    {
        Task<GetCourseByIdResponse> Execute(Guid id);
    }
}