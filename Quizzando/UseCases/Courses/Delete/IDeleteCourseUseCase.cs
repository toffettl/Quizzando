namespace Quizzando.UseCases.Courses.Delete
{
    public interface IDeleteCourseUseCase
    {
        Task Execute(Guid id);
    }
}