using Quizzando.Communication.Requests.Question;
using Quizzando.Communication.Responses.Question;

namespace Quizzando.UseCases.Questions.Create
{
    public interface ICreateQuestionUseCase
    {
        Task<QuestionResponse> Execute(QuestionRequest request);
    }
}
