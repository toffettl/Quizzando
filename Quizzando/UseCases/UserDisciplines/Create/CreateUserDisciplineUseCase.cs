using AutoMapper;
using Quizzando.Communication.Requests.UserDiscipline;
using Quizzando.Communication.Responses.UserDiscipline;
using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.UserDisciplineRepositories;
using Quizzando.Exception.ExceptionsBase;
using Quizzando.Models;

namespace Quizzando.UseCases.UserDisciplines.Create
{
    public class CreateUserDisciplineUseCase : ICreateUserDisciplineUseCase
    {
        private readonly IUserDisciplineWriteOnlyRepository _userDisciplineWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserDisciplineUseCase(
            IUserDisciplineWriteOnlyRepository userDisciplineWriteOnlyRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _userDisciplineWriteOnlyRepository = userDisciplineWriteOnlyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDisciplineResponse> Execute(UserDisciplineRequest request)
        {
            Validate(request);

            var userDiscipline = _mapper.Map<UserDiscipline>(request);

            await _userDisciplineWriteOnlyRepository.Add(userDiscipline);

            await _unitOfWork.Commit();

            return _mapper.Map<UserDisciplineResponse>(userDiscipline);
        }

        private void Validate(UserDisciplineRequest request)
        {
            var result = new UserDisciplineValidator().Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
