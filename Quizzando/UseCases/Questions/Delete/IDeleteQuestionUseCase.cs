namespace Quizzando.UseCases.Questions.Delete
{
    public interface IDeleteQuestionUseCase
    {
        Task Execute(Guid id);
    }
}
