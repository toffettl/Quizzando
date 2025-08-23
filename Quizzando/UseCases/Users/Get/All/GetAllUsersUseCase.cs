using AutoMapper;
using Quizzando.Communication.Responses.User;
using Quizzando.DataAccess.Repositories.UserRepositories;
using Quizzando.Exception.ExceptionsBase;

namespace Quizzando.UseCases.Users.Get.All
{
    public class GetAllUsersUseCase : IGetAllUsersUseCase
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IMapper _mapper;

        public GetAllUsersUseCase(
            IUserReadOnlyRepository userReadOnlyRepository,
            IMapper mapper
            )
        {
            _userReadOnlyRepository = userReadOnlyRepository;
            _mapper = mapper;
        }

        public async Task<UserGetAllResponse> Execute()
        {
            var users = await _userReadOnlyRepository.GetAllUsers();

            return new UserGetAllResponse
            {
                Users = _mapper.Map<List<UserGetByIdResponse>>(users)
            };
        }
    }
}