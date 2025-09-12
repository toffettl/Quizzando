using AutoMapper;
using Quizzando.Communication.Responses.Alternatives;
using Quizzando.DataAccess.Repositories.AlternativesRepositories;
using Quizzando.Exception;

namespace Quizzando.UseCases.Alternative.Get.ById
{
    public class GetAlternativeByIdUseCase : IGetAlternativeByIdUseCase
    {
        private readonly IAlternativeReadOnlyRepository _alternativeReadOnlyRepository;
        private readonly IMapper _mapper;

        public GetAlternativeByIdUseCase(
            IAlternativeReadOnlyRepository alternativeReadOnlyRepository,
            IMapper mapper)
        {
            _alternativeReadOnlyRepository = alternativeReadOnlyRepository;
            _mapper = mapper;
        }

        public async Task<AlternativeResponse> Execute(Guid id)
        {
            var alternative = await _alternativeReadOnlyRepository.GetById(id);

            if (alternative == null)
            {
                throw new DirectoryNotFoundException(ResourceErrorMessages.ALTERNATIVE_NOT_FOUND);
            }

            return _mapper.Map<AlternativeResponse>(alternative);
        }
    }
}
