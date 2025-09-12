using AutoMapper;
using Quizzando.Communication.Requests.Alternatives;
using Quizzando.Communication.Responses.Alternatives;
using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.AlternativesRepositories;
using Quizzando.Exception.ExceptionsBase;

namespace Quizzando.UseCases.Alternative.Create
{
    public class CreateAlternativeUseCase : ICreateAlternativeUseCase
    {
        private readonly IAlternativeWriteOnlyRepository _alternativeWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAlternativeUseCase(
            IAlternativeWriteOnlyRepository alternativeWriteOnlyRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _alternativeWriteOnlyRepository = alternativeWriteOnlyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AlternativeResponse> Execute(AlternativeRequest request)
        {
            Validate(request);

            var alternative = _mapper.Map<Models.Alternative>(request);

            await _alternativeWriteOnlyRepository.Add(alternative);

            await _unitOfWork.Commit();

            return _mapper.Map<AlternativeResponse>(alternative);
        }

        private void Validate(AlternativeRequest request)
        {
            var result = new AlternativeValidator().Validate(request);

            if (result.IsValid == false)
            {
                var erroMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(erroMessages);
            }
        }
    }
}
