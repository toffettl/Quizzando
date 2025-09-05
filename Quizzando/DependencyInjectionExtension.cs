using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Quizzando.AutoMapper;
using Quizzando.DataAccess;
using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.CourseRepositories;
using Quizzando.DataAccess.Repositories.DisciplineRepositories;
using Quizzando.DataAccess.Repositories.DisciplineRepository;
using Quizzando.DataAccess.Repositories.QuestionRepositories;
using Quizzando.DataAccess.Repositories.UserRepositories;
using Quizzando.Security.Cryptography;
using Quizzando.Security.Tokens;
using Quizzando.UseCases.Courses.Create;
using Quizzando.UseCases.Courses.Delete;
using Quizzando.UseCases.Courses.GetAll;
using Quizzando.UseCases.Courses.GetById;
using Quizzando.UseCases.Courses.Update;
using Quizzando.UseCases.Disciplines.Create;
using Quizzando.UseCases.Disciplines.Delete;
using Quizzando.UseCases.Disciplines.GetAll;
using Quizzando.UseCases.Disciplines.GetById;
using Quizzando.UseCases.Disciplines.Update;
using Quizzando.UseCases.Users.Delete;
using Quizzando.UseCases.Users.Get.All;
using Quizzando.UseCases.Users.Get.ById;
using Quizzando.UseCases.Questions.Create;
using Quizzando.UseCases.Questions.Delete;
using Quizzando.UseCases.Questions.GetAll;
using Quizzando.UseCases.Questions.GetById;
using Quizzando.UseCases.Questions.UpdateById;
using Quizzando.UseCases.Users.Login;
using Quizzando.UseCases.Users.Register;
using Quizzando.UseCases.Users.Update;
using Quizzando.Security.Tokens.AccessToken;
using Quizzando.Security.Tokens.RecoverToken;

namespace Quizzando
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
            AddAutoMapper(services);
            AddUseCases(services);
            AddToken(services, configuration);
        }


        private static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<ICourseWriteOnlyRepository, CourseRepository>();
            services.AddScoped<ICourseReadOnlyRepository, CourseRepository>();
            services.AddScoped<IUserUpdateOnlyRepository, UserRepository>();
            services.AddScoped<IDisciplineReadOnlyRepository, DisciplineRepository>();
            services.AddScoped<IDisciplineWriteOnlyRepository, DisciplineRepository>();
            services.AddScoped<IDisciplineUpdateOnlyRepository, DisciplineRepository>();
            services.AddScoped<IQuestionWriteOnlyRepository, QuestionRepository>();
            services.AddScoped<IQuestionReadOnlyRepository, QuestionRepository>();
            services.AddScoped<IQuestionUpdateOnlyRepository, QuestionRepository>();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var conectionString = configuration["ConnectionStrings:DefaultConnection"];

            services.AddDbContext<QuizzandoDbContext>(config =>
                config.UseNpgsql(conectionString));
        }

        private static void AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IRecoverTokenService, RecoverTokenService>();

            services.AddScoped<IPasswordEncripter, Quizzando.Security.Cryptography.BCrypto>();

            services.Scan(scan => scan
                .FromAssembliesOf(typeof(IRegisterUserUseCase))
                .AddClasses(classes => classes.Where(c => c.Name.EndsWith("UseCase")))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }

        private static void AddToken(IServiceCollection services, IConfiguration configuration)
        {
            var expirationTimeMinutes = Convert.ToUInt32(configuration["JWT_EXPIRATION_MINUTES"]);
            var signingKey = configuration["JWT_SECRET"];

            services.AddScoped<IAccessTokenGenerator>(config => new AccessTokenGenerator(expirationTimeMinutes, signingKey!));
        }
    }
}
