namespace Quizzando.UseCases.Disciplines.UpdateAddCourse
{
    public interface IUpdateDisciplineAddCourseUseCase
    {
        Task Execute(Guid id, Guid courseId);
    }
}
