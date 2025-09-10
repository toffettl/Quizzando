using AutoMapper;
using Quizzando.Communication.Responses.Course;
using Quizzando.DataAccess.Repositories.CourseRepositories;
using Quizzando.Exception;
using Quizzando.Exception.ExceptionsBase;
using Quizzando.Models;

namespace Quizzando.UseCases.Courses.GetByDisciplineId
{
    public class GetCourseByDisciplineIdUseCase : IGetCourseByDisciplineIdUseCase
    {
        private readonly ICourseReadOnlyRepository _repository;
        private readonly IMapper _mapper;

        public GetCourseByDisciplineIdUseCase(
            ICourseReadOnlyRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CourseResponseJson>> Execute(Guid disciplineId)
        {
            var courses = await _repository.GetCourseByDisciplineId(disciplineId);

            if( courses.Count == 0)
            {
                throw new NotFoundException(ResourceErrorMessages.COURSE_NOT_FOUND);
            }

            List<CourseResponseJson> responses = _mapper.Map<List<CourseResponseJson>>(courses);

            return responses;
        }
    }
}
