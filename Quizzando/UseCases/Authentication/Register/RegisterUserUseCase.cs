using AutoMapper;
using FluentValidation.Results;
using Quizzando.Communication.Requests.Authentication;
using Quizzando.Communication.Responses.Authentication;
using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.UserRepositories;
using Quizzando.Exception;
using Quizzando.Exception.ExceptionsBase;
using Quizzando.Security.Cryptography;

namespace Quizzando.UseCases.Authentication.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepostory;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepostory;
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterUserUseCase(IUserWriteOnlyRepository userWriteOnlyRepostory, 
            IMapper mapper, 
            IUnitOfWork unitOfWork,
            IUserReadOnlyRepository userReadOnlyRepository,
            IPasswordEncripter passwordEncripter)
        {
            _userWriteOnlyRepostory = userWriteOnlyRepostory;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userReadOnlyRepostory = userReadOnlyRepository;
            _passwordEncripter = passwordEncripter;
        }
        public async Task<UserRegisterResponse> Execute(UserRegisterRequest request)
        {
            await Validate(request);

            var user = _mapper.Map<Models.User>(request);

            user.Password = _passwordEncripter.Encrypt(request.Password!);

            await _userWriteOnlyRepostory.Add(user);

            await _unitOfWork.Commit();

            return _mapper.Map<UserRegisterResponse>(user);
        }

        private async Task Validate(UserRegisterRequest request)
        {
            var result = new RegisterUserValidator().Validate(request);

            var emailExist = await _userReadOnlyRepostory.ExistActiveUserWithEmail(request.Email!);
            if (emailExist)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_REGISTERED));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
