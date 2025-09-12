using AutoMapper;
using Quizzando.Communication.Requests.Alternatives;
using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.AlternativesRepositories;
using Quizzando.Exception;
using Quizzando.Exception.ExceptionsBase;

namespace Quizzando.UseCases.Alternative.Update
{
    public class UpdateAlternativeUseCase : IUpdateAlternativeUseCase
    {
        private readonly IAlternativeReadOnlyRepository _alternativeReadOnlyRepository;
        private readonly IAlternativeUpdateOnlyRepository _alternativeUpdateOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAlternativeUseCase(
            IAlternativeReadOnlyRepository alternativeReadOnlyRepository,
            IAlternativeUpdateOnlyRepository alternativeUpdateOnlyRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _alternativeReadOnlyRepository = alternativeReadOnlyRepository;
            _alternativeUpdateOnlyRepository = alternativeUpdateOnlyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Execute(Guid id, AlternativeRequest request)
        {
            Validate(request);

            var alternative = await _alternativeReadOnlyRepository.GetById(id);

            if (alternative is null)
            {
                throw new NotFoundException(ResourceErrorMessages.ALTERNATIVE_NOT_FOUND);
            }

            _mapper.Map(request, alternative);
            alternative.UpdatedAt = DateTime.UtcNow;

            _alternativeUpdateOnlyRepository.Update(alternative);

            await _unitOfWork.Commit();
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
