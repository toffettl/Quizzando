using Quizzando.Communication.Requests.Question;

namespace Quizzando.UseCases.Questions.UpdateById
{
    public interface IUpdateByIdQuestionUseCase
    {
        Task Execute(Guid id, QuestionRequest request);
    }
}
