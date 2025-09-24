using AutoMapper;
using Quizzando.Communication.Requests.Disciplines;
using Quizzando.Communication.Responses.Disciplines;
using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.DisciplineRepository;
using Quizzando.Exception.ExceptionsBase;
using Quizzando.Models;

namespace Quizzando.UseCases.Disciplines.Create
{
    public class CreateDisciplineUseCase : ICreateDisciplineUseCase
    {
        private readonly IDisciplineWriteOnlyRepository _disciplineWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDisciplineUseCase(
            IDisciplineWriteOnlyRepository disciplineWriteOnlyRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _disciplineWriteOnlyRepository = disciplineWriteOnlyRepository;
            _unitOfWork = unitOfWork; 
            _mapper = mapper;
        }

        public async Task<DisciplineResponse> Execute(DisciplineRequest request)
        {
            Validate(request);

            var discipline = _mapper.Map<Discipline>(request);

            await _disciplineWriteOnlyRepository.Add(discipline);

            await _unitOfWork.Commit();

            return _mapper.Map<DisciplineResponse>(discipline);
        }

        private void Validate(DisciplineRequest request)
        {
            var result = new DisciplineValidator().Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
