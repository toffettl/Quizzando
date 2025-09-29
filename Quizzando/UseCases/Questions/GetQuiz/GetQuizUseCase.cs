using AutoMapper;
using Quizzando.Communication.Requests.Question;
using Quizzando.Communication.Responses.Answer;
using Quizzando.Communication.Responses.Question;
using Quizzando.DataAccess.Repositories.QuestionRepositories;

namespace Quizzando.UseCases.Questions.GetQuiz
{
    public class GetQuizUseCase : IGetQuizUseCase
    {
        private readonly IQuestionReadOnlyRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetQuizUseCase(
            IQuestionReadOnlyRepository questionRepository,
            IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<ResponseQuizJson> ExecuteAsync(RequestQuizJson request)
        {
            var questions = await _questionRepository.GetQuiz(request.DisciplineId);

            var random = new Random();
            var shuffledQuestions = questions.OrderBy(q => random.Next()).ToList();

            return new ResponseQuizJson
            {
                DisciplineId = request.DisciplineId,
                Questions = _mapper.Map<List<QuestionResponse>>(shuffledQuestions)
            };
        }
    }
}
