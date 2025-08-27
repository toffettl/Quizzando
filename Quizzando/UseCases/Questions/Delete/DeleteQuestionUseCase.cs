using AutoMapper;
using Quizzando.DataAccess.Repositories.QuestionRepositories;
using Quizzando.DataAccess.Repositories;
using System.Data;
using Quizzando.Exception;

namespace Quizzando.UseCases.Questions.Delete
{
    public class DeleteQuestionUseCase : IDeleteQuestionUseCase
    {
        private readonly IQuestionWriteOnlyRepository _questionWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteQuestionUseCase(
            IQuestionWriteOnlyRepository questionWriteOnlyRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _questionWriteOnlyRepository = questionWriteOnlyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Execute(Guid id)
        {
            var result = await _questionWriteOnlyRepository.Delete(id);

            if(result == false)
            {
               throw new EntryPointNotFoundException(ResourceErrorMessages.QUESTION_NOT_FOUND);
            }

            await _unitOfWork.Commit();
        }
    }
}
