using AutoMapper;
using Quizzando.Communication.Requests.Disciplines;
using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.DisciplineRepositories;
using Quizzando.Exception;
using Quizzando.Exception.ExceptionsBase;

namespace Quizzando.UseCases.Disciplines.Update
{
    public class UpdateDisciplineUseCase : IUpdateDisciplineUseCase
    {
        private readonly IDisciplineReadOnlyRepository _disciplineReadOnlyRepository;
        private readonly IDisciplineUpdateOnlyRepository _disciplineUpdateOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDisciplineUseCase(
            IDisciplineReadOnlyRepository disciplineReadOnlyRepository,
            IDisciplineUpdateOnlyRepository disciplineUpdateOnlyRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _disciplineReadOnlyRepository = disciplineReadOnlyRepository;
            _disciplineUpdateOnlyRepository = disciplineUpdateOnlyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Execute(Guid id, DisciplineRequest request)
        {
            Validate(request);

            var discipline = await _disciplineReadOnlyRepository.GetById(id);

            if (discipline is null)
            {
                throw new DirectoryNotFoundException(ResourceErrorMessages.DISCIPLINE_NOT_FOUND);
            }

            _mapper.Map(request, discipline);
            discipline.UpdatedAt = DateTime.UtcNow;

            _disciplineUpdateOnlyRepository.Update(discipline);

            await _unitOfWork.Commit();
        }

        private void Validate(DisciplineRequest request)
        {
            var result = new DisciplineValidator().Validate(request);

            if (result.IsValid == false)
            {
                var erroMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(erroMessages);
            }
        }
    }
}
