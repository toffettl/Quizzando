using Quizzando.Communication.Requests.UserDiscipline;
using Quizzando.Communication.Responses.UserDiscipline;

namespace Quizzando.UseCases.UserDisciplines.Create
{
    public interface ICreateUserDisciplineUseCaseRelation
    {
        Task<UserDisciplineRelationResponse> Execute(UserDisciplineRelationRequest request);
    }
}
