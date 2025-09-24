using Quizzando.Communication.Responses;
using Quizzando.Communication.Responses.User;

namespace Quizzando.UseCases.Users.GetByRanking
{
    public interface IGetUsersByRankingUseCase
    {
        Task<PagedResult<UserGetByRankingResponse>> Execute(int page, int pageSize);
    }
}
