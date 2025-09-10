using Microsoft.EntityFrameworkCore;
using Quizzando.Models;

namespace Quizzando.DataAccess
{
    public class QuizzandoDbContext : DbContext
    {
        public QuizzandoDbContext(DbContextOptions<QuizzandoDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> user {  get; set; }
        public DbSet<Question> question { get; set; }
        public DbSet<Discipline> discipline { get; set; }
        public DbSet<Course> course { get; set; }
    }
}
