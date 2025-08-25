namespace Quizzando.UseCases.Disciplines.Delete
{
    public interface IDeleteDisciplineUseCase
    {
        Task Execute(Guid id);
    }
}
