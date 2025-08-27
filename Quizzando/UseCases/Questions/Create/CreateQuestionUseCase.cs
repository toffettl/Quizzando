using AutoMapper;
using Quizzando.Communication.Requests.Question;
using Quizzando.Communication.Responses.Question;
using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.QuestionRepositories;
using Quizzando.Exception.ExceptionsBase;
using Quizzando.Models;

namespace Quizzando.UseCases.Questions.Create
{
    public class CreateQuestionUseCase : ICreateQuestionUseCase
    {
        private readonly IQuestionWriteOnlyRepository _questionWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateQuestionUseCase(
            IQuestionWriteOnlyRepository questionWriteOnlyRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _questionWriteOnlyRepository = questionWriteOnlyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<QuestionResponse> Execute(QuestionRequest request)
        {
            Validate(request);

            var question = _mapper.Map<Question>(request);

            question.Id = Guid.NewGuid();

            await _questionWriteOnlyRepository.Add(question);

            await _unitOfWork.Commit();

            return _mapper.Map<QuestionResponse>(question);
        }
        
        private void Validate(QuestionRequest request)
        {
            var validator = new QuestionValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
