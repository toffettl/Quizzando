using Quizzando.Communication.Responses.Disciplines;

namespace Quizzando.UseCases.Disciplines.GetAll
{
    public interface IGetAllDisciplinesUseCase
    {
        Task<DisciplineResponses> Execute();
    }
}
