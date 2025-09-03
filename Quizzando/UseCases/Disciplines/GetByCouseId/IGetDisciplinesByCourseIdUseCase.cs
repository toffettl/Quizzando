using Quizzando.Communication.Responses.Disciplines;

namespace Quizzando.UseCases.Disciplines.GetByCouseId
{
    public interface IGetDisciplinesByCourseIdUseCase
    {
        Task<DisciplineResponses> Execute(Guid courseId);
    }
}
