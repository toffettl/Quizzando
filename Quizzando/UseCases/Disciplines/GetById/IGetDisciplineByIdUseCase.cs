using Quizzando.Communication.Responses.Course.Discipline;

namespace Quizzando.UseCases.Disciplines.GetById
{
    public interface IGetDisciplineByIdUseCase
    {
        Task<DisciplineResponse> Execute(Guid id);
    }
}
