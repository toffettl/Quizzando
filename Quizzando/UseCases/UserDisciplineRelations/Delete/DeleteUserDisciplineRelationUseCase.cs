using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.UserDisciplineRepositories;
using Quizzando.Exception;
using Quizzando.Exception.ExceptionsBase;
using Quizzando.UseCases.UserDisciplines.GetByUserIdAndDisciplineId;

namespace Quizzando.UseCases.UserDisciplineRelations.Delete
{
    public class DeleteUserDisciplineRelationUseCase
        : IDeleteUserDisciplineRelationUseCase
    {
        private readonly IUserDisciplineRelationWriteOnlyRepository _userDisciplineRelationWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserDisciplineRelationUseCase(
            IUserDisciplineRelationWriteOnlyRepository userDisciplineRelationWriteOnlyRepository,
            IUnitOfWork unitOfWork)
        {
            _userDisciplineRelationWriteOnlyRepository = userDisciplineRelationWriteOnlyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(Guid id)
        {
            var result = await _userDisciplineRelationWriteOnlyRepository.Delete(id);

            if (result != true)
            {
                throw new NotFoundException(ResourceErrorMessages.USER_DISCIPLINE_RELATION_NOT_FOUND);
            }

            await _unitOfWork.Commit();
        }
    }
}
