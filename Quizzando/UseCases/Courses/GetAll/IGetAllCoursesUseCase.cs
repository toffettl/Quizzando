using Quizzando.Communication.Responses.Course;

namespace Quizzando.UseCases.Courses.GetAll
{
    public interface IGetAllCoursesUseCase
    {
        Task<GetAllCoursesResponse> Execute();
    }
}