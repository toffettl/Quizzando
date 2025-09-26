using AutoMapper;
using Quizzando.Communication.Responses.UserDiscipline;
using Quizzando.Communication.Responses.UserDisciplineRelation;
using Quizzando.DataAccess.Repositories.UserDisciplineRepositories;

namespace Quizzando.UseCases.UserDisciplineRelations.GetByDisciplineId
{
    public class GetUserDisciplineRelationsByDisciplineIdUseCase : IGetUserDisciplineRelationsByDisciplineIdUseCase
    {
        private readonly IUserDisciplineRelationReadOnlyRepository _userDisciplineRelationReadOnlyRepository;
        private readonly IMapper _mapper;

        public GetUserDisciplineRelationsByDisciplineIdUseCase(
            IUserDisciplineRelationReadOnlyRepository userDisciplineRelationReadOnlyRepository,
            IMapper mapper)
        {
            _userDisciplineRelationReadOnlyRepository = userDisciplineRelationReadOnlyRepository;
            _mapper = mapper;
        }

        public async Task<UserDisciplineRelationResponses> Execute(Guid disciplineId)
        {
            var userDisciplineRelations = await _userDisciplineRelationReadOnlyRepository.GetUserDisciplineRelationsByDisciplineId(disciplineId);

            return new UserDisciplineRelationResponses
            {
                UserDisciplineRelations = _mapper.Map<List<UserDisciplineRelationResponse>>(userDisciplineRelations)
            };
        }
    }
}
