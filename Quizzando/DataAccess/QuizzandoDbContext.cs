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

        public DbSet<User> User {  get; set; }
    }
}
