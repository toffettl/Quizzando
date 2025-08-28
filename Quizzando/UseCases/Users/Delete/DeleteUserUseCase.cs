using AutoMapper;
using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.UserRepositories;
using Quizzando.Exception;
using Quizzando.Exception.ExceptionsBase;

namespace Quizzando.UseCases.Users.Delete
{
    public class DeleteUserUseCase : IDeleteUserUseCase
    {
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserUseCase(
            IUserWriteOnlyRepository userWriteOnlyRepository,
            IUnitOfWork unitOfWork)
        {
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(Guid id)
        {
            var result = await _userWriteOnlyRepository.Delete(id);

            if (result != true)
            {
                throw new NotFoundException(ResourceErrorMessages.USER_NOT_FOUND);
            }

            await _unitOfWork.Commit();
        }
    }
}
