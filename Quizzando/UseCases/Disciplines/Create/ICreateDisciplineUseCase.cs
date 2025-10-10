using Quizzando.Communication.Requests.Disciplines;
using Quizzando.Communication.Responses.Discipline;

namespace Quizzando.UseCases.Disciplines.Create
{
    public interface ICreateDisciplineUseCase
    {
        Task<DisciplineResponse> Execute(DisciplineRequest request);
    }
}
