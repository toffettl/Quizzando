using Quizzando.Communication.Responses.Discipline;

namespace Quizzando.UseCases.Disciplines.GetAll
{
    public interface IGetAllDisciplinesUseCase
    {
        Task<DisciplineResponses> Execute();
    }
}
