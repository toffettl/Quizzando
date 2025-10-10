using AutoMapper;
using Quizzando.Communication.Responses.Discipline;
using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.DisciplineRepositories;
using Quizzando.Exception;

namespace Quizzando.UseCases.Disciplines.GetById
{
    public class GetDisciplineByIdUseCase : IGetDisciplineByIdUseCase
    {
        private readonly IDisciplineReadOnlyRepository _disciplineReadOnlyRepository;
        private readonly IMapper _mapper;

        public GetDisciplineByIdUseCase(
            IDisciplineReadOnlyRepository disciplineReadOnlyRepository,
            IMapper mapper)
        {
            _disciplineReadOnlyRepository = disciplineReadOnlyRepository;
            _mapper = mapper;
        }

        public async Task<DisciplineResponse> Execute(Guid id)
        {
            var discipline = await _disciplineReadOnlyRepository.GetById(id);

            if (discipline == null)
            {
                throw new DirectoryNotFoundException(ResourceErrorMessages.DISCIPLINE_NOT_FOUND);
            }

            return _mapper.Map<DisciplineResponse>(discipline);
        }
    }
}
