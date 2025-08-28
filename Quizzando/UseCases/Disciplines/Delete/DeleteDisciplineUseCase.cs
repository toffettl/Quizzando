using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.DisciplineRepository;
using Quizzando.Exception;
using Quizzando.Exception.ExceptionsBase;

namespace Quizzando.UseCases.Disciplines.Delete
{
    public class DeleteDisciplineUseCase : IDeleteDisciplineUseCase
    {
        private readonly IDisciplineWriteOnlyRepository _disciplineWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDisciplineUseCase(
            IDisciplineWriteOnlyRepository disciplineWriteOnlyRepository,
            IUnitOfWork unitOfWork)
        {
            _disciplineWriteOnlyRepository = disciplineWriteOnlyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(Guid id)
        {
            var result = await _disciplineWriteOnlyRepository.Delete(id);

            if (result != true)
            {
                throw new NotFoundException(ResourceErrorMessages.DISCIPLINE_NOT_FOUND);
            }

            await _unitOfWork.Commit();
        }
    }
}
