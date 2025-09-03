using Quizzando.Communication.Responses.Disciplines;

namespace Quizzando.UseCases.Disciplines.GetByCouseId
{
    public interface IGetDisciplinesByCouseId
    {
        Task<DisciplineResponses> Execute(Guid courseId);
    }
}
