using AutoMapper;
using Quizzando.Communication.Responses.Disciplines;
using Quizzando.DataAccess.Repositories.DisciplineRepositories;

namespace Quizzando.UseCases.Disciplines.GetByCouseId
{
    public class GetDisciplinesByCourseIdUseCase : IGetDisciplinesByCourseIdUseCase
    {
        private readonly IDisciplineReadOnlyRepository _disciplineReadOnlyRepository;
        private readonly IMapper _mapper;

        public GetDisciplinesByCourseIdUseCase(
            IDisciplineReadOnlyRepository disciplineReadOnlyRepository,
            IMapper mapper)
        {
            _disciplineReadOnlyRepository = disciplineReadOnlyRepository;
            _mapper = mapper;
        }

        public async Task<DisciplineResponses> Execute(Guid courseId)
        {
            var disciplines = await _disciplineReadOnlyRepository.GetByCourseId(courseId);

            return new DisciplineResponses
            {
                Disciplines = _mapper.Map<List<DisciplineResponse>>(disciplines)
            };
        }
    }
}
