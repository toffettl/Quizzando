using Quizzando.Communication.Requests.Disciplines;

namespace Quizzando.UseCases.Disciplines.Update
{
    public interface IUpdateDisciplineUseCase
    {
        Task Execute(Guid id, DisciplineRequest request);
    }
}
