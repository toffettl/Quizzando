using AutoMapper;
using Quizzando.Communication.Responses.Question;
using Quizzando.DataAccess.Repositories.DisciplineRepositories;
using Quizzando.DataAccess.Repositories.QuestionRepositories;
using Quizzando.Models;

namespace Quizzando.UseCases.Questions.GetQuestionsByDisciplineId
{
    public class GetQuestionsByDisciplineIdUseCase : IGetQuestionsByDisplineIdUseCase
    {
        private readonly IQuestionReadOnlyRepository _questionReadOnlyRepository;

        private readonly IMapper _mapper;

        public GetQuestionsByDisciplineIdUseCase(
            IQuestionReadOnlyRepository questionReadOnlyRepository,
            IMapper mapper)
        {
            _questionReadOnlyRepository = questionReadOnlyRepository;
            _mapper = mapper;
        }

        public async Task<QuestionsResponse> Execute(Guid disciplineId)
        {
            var questions = await _questionReadOnlyRepository.GetByDisciplineId(disciplineId);

            return new QuestionsResponse
            {
                Questions = _mapper.Map<List<QuestionResponse>>(questions)
            };
        }
    }
}
