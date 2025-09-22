using Quizzando.Communication.Responses.UserDisciplineRelation;
using Quizzando.Models;

namespace Quizzando.UseCases.UserDisciplineRelations.GetByUserId
{
    public interface IGetUserDiciplineRelationsByUserIdUseCase
    {
        Task<UserDisciplineRelationResponses> Execute(Guid userId);
    }
}
