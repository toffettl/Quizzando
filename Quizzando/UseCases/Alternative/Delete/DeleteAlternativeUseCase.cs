using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.AlternativesRepositories;
using Quizzando.Exception;
using Quizzando.Exception.ExceptionsBase;

namespace Quizzando.UseCases.Alternative.Delete
{
    public class DeleteAlternativeUseCase : IDeleteAlternativeUseCase
    {
        private readonly IAlternativeWriteOnlyRepository _alternativeWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAlternativeUseCase(
            IAlternativeWriteOnlyRepository alternativeWriteOnlyRepository,
            IUnitOfWork unitOfWork)
        {
            _alternativeWriteOnlyRepository = alternativeWriteOnlyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(Guid id)
        {
            var result = await _alternativeWriteOnlyRepository.Delete(id);

            if (result != true)
            {
                throw new NotFoundException(ResourceErrorMessages.ALTERNATIVE_NOT_FOUND);
            }

            await _unitOfWork.Commit();
        }
    }
}
