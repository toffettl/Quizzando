using AutoMapper;
using Quizzando.Communication.Responses.Question;
using Quizzando.DataAccess.Repositories.QuestionRepositories;
using Quizzando.Exception;

namespace Quizzando.UseCases.Questions.GetById
{
    public class GetByIdQuestionUseCase : IGetByIdQuestionUseCase
    {
        private readonly IQuestionReadOnlyRepository _questionReadOnlyRepository;

        private readonly IMapper _mapper;

        public GetByIdQuestionUseCase(
            IQuestionReadOnlyRepository questionReadOnlyRepository,
            IMapper mapper)
        {
            _questionReadOnlyRepository = questionReadOnlyRepository;
            _mapper = mapper;
        }

        public async Task<QuestionResponse> Execute(Guid id)
        {
            var question = await _questionReadOnlyRepository.GetById(id);

            if (question == null)
            {
                throw new EntryPointNotFoundException(ResourceErrorMessages.QUESTION_NOT_FOUND);
            }
            return _mapper.Map<QuestionResponse>(question);
        }
    }
}
