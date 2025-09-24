using Quizzando.Communication.Responses.Question;

namespace Quizzando.UseCases.Questions.GetById
{
    public interface IGetByIdQuestionUseCase
    {
        Task<QuestionResponse> Execute(Guid id);
    }
}
