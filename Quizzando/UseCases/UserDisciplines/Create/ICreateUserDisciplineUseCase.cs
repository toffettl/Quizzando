using Quizzando.Communication.Requests.UserDiscipline;
using Quizzando.Communication.Responses.UserDiscipline;

namespace Quizzando.UseCases.UserDisciplines.Create
{
    public interface ICreateUserDisciplineUseCase
    {
        Task<UserDisciplineResponse> Execute(UserDisciplineRequest request);
    }
}
