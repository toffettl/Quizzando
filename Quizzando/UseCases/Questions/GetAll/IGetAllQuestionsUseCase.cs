using Quizzando.Communication.Responses.Question;

namespace Quizzando.UseCases.Questions.GetAll
{
    public interface IGetAllQuestionsUseCase
    {
        Task<QuestionsResponse> Execute();
    }
}
