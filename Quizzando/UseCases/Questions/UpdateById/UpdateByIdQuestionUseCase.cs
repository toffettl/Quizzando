using AutoMapper;
using Quizzando.DataAccess.Repositories.QuestionRepositories;
using Quizzando.DataAccess.Repositories;
using Quizzando.Communication.Requests.Question;
using Quizzando.Exception.ExceptionsBase;
using Quizzando.Exception;

namespace Quizzando.UseCases.Questions.UpdateById
{
    public class UpdateByIdQuestionUseCase : IUpdateByIdQuestionUseCase
    {
        private readonly IQuestionUpdateOnlyRepository _questionUpdateOnlyRepository;
        private readonly IQuestionReadOnlyRepository _questionReadOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateByIdQuestionUseCase(
            IQuestionUpdateOnlyRepository questionUpdateOnlyRepository,
            IQuestionReadOnlyRepository questionReadOnlyRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _questionUpdateOnlyRepository = questionUpdateOnlyRepository;
            _questionReadOnlyRepository = questionReadOnlyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Execute(Guid id, QuestionRequest request)
        {
            Validate(request);

            var question = await _questionReadOnlyRepository.GetById(id);

            if (question == null)
            {
                throw new NotFoundException(ResourceErrorMessages.QUESTION_NOT_FOUND);
            }

            _mapper.Map(request, question);

            _questionUpdateOnlyRepository.Update(question);

            await _unitOfWork.Commit();
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
