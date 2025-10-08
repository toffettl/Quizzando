using Quizzando.Communication.Responses.Course.Discipline;

namespace Quizzando.UseCases.Disciplines.GetAll
{
    public interface IGetAllDisciplinesUseCase
    {
        Task<DisciplineResponses> Execute();
    }
}
