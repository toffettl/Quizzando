using AutoMapper;
using Quizzando.Communication.Responses.Course.Discipline;
using Quizzando.DataAccess.Repositories.DisciplineRepositories;

namespace Quizzando.UseCases.Disciplines.GetAll
{
    public class GetAllDisciplinesUseCase : IGetAllDisciplinesUseCase
    {
        private readonly IDisciplineReadOnlyRepository _disciplineReadOnlyRepository;
        private readonly IMapper _mapper;

        public GetAllDisciplinesUseCase(
            IDisciplineReadOnlyRepository disciplineReadOnlyRepository,
            IMapper mapper)
        {
            _disciplineReadOnlyRepository = disciplineReadOnlyRepository;
            _mapper = mapper;
        }
        public async Task<DisciplineResponses> Execute()
        {
            var disciplines = await _disciplineReadOnlyRepository.GetAll();

            return new DisciplineResponses
            {
                Disciplines = _mapper.Map<List<DisciplineResponse>>(disciplines)
            };
        }
    }
}
