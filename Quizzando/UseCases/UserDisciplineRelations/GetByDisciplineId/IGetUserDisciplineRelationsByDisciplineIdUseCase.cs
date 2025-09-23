using Quizzando.Communication.Responses.UserDisciplineRelation;

namespace Quizzando.UseCases.UserDisciplineRelations.GetByDisciplineId
{
    public interface IGetUserDisciplineRelationsByDisciplineIdUseCase
    {
        Task<UserDisciplineRelationResponses> Execute(Guid disciplineId);
    }
}
