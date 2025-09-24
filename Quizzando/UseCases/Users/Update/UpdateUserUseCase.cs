using AutoMapper;
using FluentValidation.Results;
using Quizzando.Communication.Requests.User;
using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.UserRepositories;
using Quizzando.Exception;
using Quizzando.Exception.ExceptionsBase;
using Quizzando.UseCases.Users.Register;

namespace Quizzando.UseCases.Users.Update
{
    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUserUpdateOnlyRepository _userUpdateOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserUseCase(
            IUserReadOnlyRepository userReadOnlyRepository,
            IUserUpdateOnlyRepository userUpdateOnlyRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _userReadOnlyRepository = userReadOnlyRepository;
            _userUpdateOnlyRepository = userUpdateOnlyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Execute(Guid id, UserUpdateRequest userUpdateRequest)
        {
            Validate(userUpdateRequest);

            var user = await _userReadOnlyRepository.GetUserById(id);

            if (user == null)
            {
                throw new NotFoundException(ResourceErrorMessages.USER_NOT_FOUND);
            }

            _mapper.Map(userUpdateRequest, user);

            _userUpdateOnlyRepository.Update(user);

            await _unitOfWork.Commit();
        }

        private void Validate(UserUpdateRequest request)
        {
            var result = new UpdateUserValidator().Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
