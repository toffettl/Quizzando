using AutoMapper;
using Quizzando.Communication.Requests.UserDiscipline;
using Quizzando.Communication.Responses.UserDiscipline;
using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.UserDisciplineRepositories;
using Quizzando.Exception.ExceptionsBase;
using Quizzando.Models;

namespace Quizzando.UseCases.UserDisciplines.Create
{
    public class CreateUserDisciplineUseCaseRelation : ICreateUserDisciplineUseCaseRelation
    {
        private readonly IUserDisciplineRelationWriteOnlyRepository _userDisciplineWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserDisciplineUseCaseRelation(
            IUserDisciplineRelationWriteOnlyRepository userDisciplineWriteOnlyRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _userDisciplineWriteOnlyRepository = userDisciplineWriteOnlyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDisciplineRelationResponse> Execute(UserDisciplineRelationRequest request)
        {
            Validate(request);

            var userDiscipline = _mapper.Map<UserDisciplineRelation>(request);

            await _userDisciplineWriteOnlyRepository.Add(userDiscipline);

            await _unitOfWork.Commit();

            return _mapper.Map<UserDisciplineRelationResponse>(userDiscipline);
        }

        private void Validate(UserDisciplineRelationRequest request)
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
