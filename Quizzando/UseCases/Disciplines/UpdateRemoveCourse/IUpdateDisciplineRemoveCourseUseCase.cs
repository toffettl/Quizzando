namespace Quizzando.UseCases.Disciplines.UpdateRemoveCourse
{
    public interface IUpdateDisciplineRemoveCourseUseCase
    {
        Task Execute(Guid id, Guid courseId);
    }
}
