using AutoMapper;
using Quizzando.Communication.Responses;
using Quizzando.Communication.Responses.User;
using Quizzando.DataAccess.Repositories.UserRepositories;
using Quizzando.Models;

namespace Quizzando.UseCases.Users.GetByRanking
{
    public class GetUsersByRankingUseCase :
        IGetUsersByRankingUseCase
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IMapper _mapper;

        public GetUsersByRankingUseCase(
            IUserReadOnlyRepository userReadOnlyRepository,
            IMapper mapper)
        {
            _userReadOnlyRepository = userReadOnlyRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<UserGetByRankingResponse>> Execute(int page, int pageSize)
        {
            var (users, totalCount) = await _userReadOnlyRepository.GetUsersByRanking(page, pageSize);

            List<UserGetByRankingResponse> userResponses = _mapper.Map<List<UserGetByRankingResponse>>(users);

            return new PagedResult<UserGetByRankingResponse>
            {
                Items = userResponses,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling((double)totalCount / pageSize)
            };
        }
    }
}
