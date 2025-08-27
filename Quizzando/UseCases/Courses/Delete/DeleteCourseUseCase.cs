using AutoMapper;
using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.CourseRepositories;
using Quizzando.Exception;
using Quizzando.Exception.ExceptionsBase;

namespace Quizzando.UseCases.Courses.Delete
{
    public class DeleteCourseUseCase : IDeleteCourseUseCase
    {
        private readonly ICourseReadOnlyRepository _courseReadOnlyRepository;
        private readonly ICourseWriteOnlyRepository _courseWriteOnlyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCourseUseCase(ICourseWriteOnlyRepository courseWriteOnlyRepository, IMapper mapper, IUnitOfWork unitOfWork, ICourseReadOnlyRepository courseReadOnlyRepository)
        {
            _courseWriteOnlyRepository = courseWriteOnlyRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _courseReadOnlyRepository = courseReadOnlyRepository;
        }

        public async Task Execute(Guid id)
        {
            var course = await _courseReadOnlyRepository.GetCourseById(id);

            if (course == null)
            {
                throw new NotFoundException(ResourceErrorMessages.COURSE_NOT_FOUND);
            }
            
            await _courseWriteOnlyRepository.Delete(course);
            
            await _unitOfWork.Commit();
        }
    }
}