using AutoMapper;
using Quizzando.Communication.Responses.Alternatives;
using Quizzando.DataAccess.Repositories.AlternativesRepositories;

namespace Quizzando.UseCases.Alternative.Get.All
{
    public class GetAllAlternativesUseCase : IGetAllAlternativesUseCase
    {
        private readonly IAlternativeReadOnlyRepository _alternativeReadOnlyRepository;
        private readonly IMapper _mapper;

        public GetAllAlternativesUseCase(
            IAlternativeReadOnlyRepository alternativeReadOnlyRepository,
            IMapper mapper)
        {
            _alternativeReadOnlyRepository = alternativeReadOnlyRepository;
            _mapper = mapper;
        }
        public async Task<AlternativeResponses> Execute()
        {
            var alternatives = await _alternativeReadOnlyRepository.GetAll();

            return new AlternativeResponses
            {
                Alternatives = _mapper.Map<List<AlternativeResponse>>(alternatives)
            };
        }
    }
}
