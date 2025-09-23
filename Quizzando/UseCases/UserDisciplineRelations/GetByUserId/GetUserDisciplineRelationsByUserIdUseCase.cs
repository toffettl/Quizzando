using AutoMapper;
using Quizzando.Communication.Responses.UserDiscipline;
using Quizzando.Communication.Responses.UserDisciplineRelation;
using Quizzando.DataAccess.Repositories.UserDisciplineRepositories;
using Quizzando.Models;

namespace Quizzando.UseCases.UserDisciplineRelations.GetByUserId
{
    public class GetUserDisciplineRelationsByUserIdUseCase : IGetUserDiciplineRelationsByUserIdUseCase
    {
        private readonly IUserDisciplineRelationReadOnlyRepository _userDisciplineRelationReadOnlyRepository;
        private readonly IMapper _mapper;

        public GetUserDisciplineRelationsByUserIdUseCase(
            IUserDisciplineRelationReadOnlyRepository userDisciplineRelationReadOnlyRepository,
            IMapper mapper)
        {
            _userDisciplineRelationReadOnlyRepository = userDisciplineRelationReadOnlyRepository;
            _mapper = mapper;
        }

        public async Task<UserDisciplineRelationResponses> Execute(Guid userId)
        {
            var userDisciplineRelations = await _userDisciplineRelationReadOnlyRepository.GetUserDisciplineRelationsByUserId(userId);

            return new UserDisciplineRelationResponses
            {
                UserDisciplineRelations = _mapper.Map<List<UserDisciplineRelationResponse>>(userDisciplineRelations)
            };
        }
    }
}
