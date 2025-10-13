using Quizzando.Communication.Responses.Discipline;

namespace Quizzando.UseCases.Disciplines.GetById
{
    public interface IGetDisciplineByIdUseCase
    {
        Task<DisciplineResponse> Execute(Guid id);
    }
}
