namespace Quizzando.UseCases.Alternative.Delete
{
    public interface IDeleteAlternativeUseCase
    {
        Task Execute(Guid id);
    }
}
