using Quizzando.Communication.Requests.Question;
using Quizzando.Communication.Responses.Question;

namespace Quizzando.UseCases.Questions.GetQuiz
{
    public interface IGetQuizUseCase
    {
        Task<ResponseQuizJson> ExecuteAsync(RequestQuizJson request);
    }
}
