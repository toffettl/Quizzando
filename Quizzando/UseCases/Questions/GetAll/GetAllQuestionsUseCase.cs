using AutoMapper;
using Quizzando.Communication.Responses.Question;
using Quizzando.DataAccess.Repositories.QuestionRepositories;
using Quizzando.Models;

namespace Quizzando.UseCases.Questions.GetAll
{
    public class GetAllQuestionsUseCase : IGetAllQuestionsUseCase
    {
       private readonly IQuestionReadOnlyRepository _questionReadOnlyRepository;

       private readonly IMapper _mapper;

        public GetAllQuestionsUseCase(
            IQuestionReadOnlyRepository questionReadOnlyRepository,
            IMapper mapper)
        {
            _questionReadOnlyRepository = questionReadOnlyRepository;
            _mapper = mapper;
        }

        public async Task<QuestionsResponse> Execute()
        {
            var questions = await _questionReadOnlyRepository.GetAll();

            return new QuestionsResponse
            {
                Questions = _mapper.Map<List<QuestionResponse>>(questions)
            };
        }
    }
}
