using Quizzando.Communication.Responses.Question;

namespace Quizzando.UseCases.Questions.GetQuestionsByDisciplineId
{
    public interface IGetQuestionsByDisplineIdUseCase
    {
        Task<QuestionsResponse> Execute(Guid disciplineId);
    }
}
