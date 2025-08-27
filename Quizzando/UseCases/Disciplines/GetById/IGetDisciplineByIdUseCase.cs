using Quizzando.Communication.Responses.Disciplines;

namespace Quizzando.UseCases.Disciplines.GetById
{
    public interface IGetDisciplineByIdUseCase
    {
        Task<DisciplineResponse> Execute(Guid id);
    }
}
