using Microsoft.EntityFrameworkCore;
using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.CourseRepositories
{
    public class CourseRepository : 
        ICourseWriteOnlyRepository, 
        ICourseReadOnlyRepository, 
        ICourseUpdateOnlyRepository
    {
        private readonly QuizzandoDbContext _dbContext;

        public CourseRepository(QuizzandoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Course course)
        {
            await _dbContext.Course.AddAsync(course);
        }

        public void Update(Course course)
        {
            _dbContext.Course.Update(course);
        }

        public void Delete(Course course)
        {
            _dbContext.Course.Remove(course);
        }

        public async Task<Course?> GetCourseById(Guid id)
        {
            return await _dbContext.Course
                .AsNoTracking()
                .AsSplitQuery()
                .Include(c => c.Disciplines)
                .FirstOrDefaultAsync(course => course.Id == id); 
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _dbContext.Course
                .AsNoTracking()
                .AsSplitQuery()
                .Include(c => c.Disciplines)
                .ToListAsync();
        }

        public async Task<List<Course>> GetCoursesByDisciplineId(Guid disciplineId)
        {
            return await _dbContext.Course
                .Where(c => c.Disciplines.Any(d => d.Id == disciplineId))
                .ToListAsync();
        }
    }
}
