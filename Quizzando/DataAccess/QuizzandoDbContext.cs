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
        public DbSet<Discipline> Discipline { get; set; }
        public DbSet<UserDisciplineRelation> UserDisciplineRelation { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discipline>()
                .HasMany(d => d.Questions)
                .WithOne(q => q.Discipline)
                .HasForeignKey(q => q.DisciplineId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
