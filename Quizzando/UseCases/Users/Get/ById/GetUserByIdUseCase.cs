using AutoMapper;
using Quizzando.Communication.Responses.User;
using Quizzando.DataAccess.Repositories.UserRepositories;
using Quizzando.Exception;
using Quizzando.Exception.ExceptionsBase;

namespace Quizzando.UseCases.Users.Get.ById
{
    public class GetUserByIdUseCase : IGetUserByIdUseCase
    {
           private readonly IUserReadOnlyRepository _userReadOnlyRepository;
           private readonly IMapper _mapper;

        public GetUserByIdUseCase(
            IUserReadOnlyRepository userReadOnlyRepository,
            IMapper mapper
            )
        {
            _userReadOnlyRepository = userReadOnlyRepository;
            _mapper = mapper;
        }

        public async Task<UserGetByIdResponse> Execute(Guid id)
        {
            var user = await _userReadOnlyRepository.GetUserById(id);

            if (user == null)
            {
                throw new NotFoundException(ResourceErrorMessages.USER_NOT_FOUND);
            }

            return _mapper.Map<UserGetByIdResponse>(user);
        }
    }
}
