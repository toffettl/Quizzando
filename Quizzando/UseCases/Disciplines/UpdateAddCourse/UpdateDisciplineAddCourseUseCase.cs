using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.CourseRepositories;
using Quizzando.DataAccess.Repositories.DisciplineRepositories;
using Quizzando.Exception;
using Quizzando.Models;

namespace Quizzando.UseCases.Disciplines.UpdateAddCourse
{
    public class UpdateDisciplineAddCourseUseCase : IUpdateDisciplineAddCourseUseCase
    {
        private readonly IDisciplineReadOnlyRepository _disciplineReadOnlyRepository;
        private readonly IDisciplineUpdateOnlyRepository _disciplineUpdateOnlyRepository;
        private readonly ICourseReadOnlyRepository _courseReadOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDisciplineAddCourseUseCase(
            IDisciplineReadOnlyRepository disciplineReadOnlyRepository,
            IDisciplineUpdateOnlyRepository disciplineUpdateOnlyRepository,
            ICourseReadOnlyRepository courseReadOnlyRepository,
            IUnitOfWork unitOfWork)
        {
            _disciplineReadOnlyRepository = disciplineReadOnlyRepository;
            _disciplineUpdateOnlyRepository = disciplineUpdateOnlyRepository;
            _courseReadOnlyRepository = courseReadOnlyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(Guid id, Guid courseId)
        {
            var discipline = await _disciplineReadOnlyRepository.GetById(id);

            if (discipline == null)
            {
                throw new DirectoryNotFoundException(ResourceErrorMessages.DISCIPLINE_NOT_FOUND);
            }

            var course = await _courseReadOnlyRepository.GetCourseById(courseId);

            if (course == null)
            {
                throw new DirectoryNotFoundException(ResourceErrorMessages.COURSE_NOT_FOUND);
            }

            discipline.Courses.Add(course);

            _disciplineUpdateOnlyRepository.Update(discipline);

            await _unitOfWork.Commit();
        }
    }
}
