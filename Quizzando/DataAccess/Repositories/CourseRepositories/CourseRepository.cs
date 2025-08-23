using Microsoft.EntityFrameworkCore;
using Quizzando.Models;

namespace Quizzando.DataAccess.Repositories.CourseRepositories
{
    public class CourseRepository : ICourseWriteOnlyRepository
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
    }
}