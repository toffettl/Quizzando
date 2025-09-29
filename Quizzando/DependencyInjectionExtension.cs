using Microsoft.EntityFrameworkCore;
using Quizzando.AutoMapper;
using Quizzando.DataAccess;
using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.CourseRepositories;
using Quizzando.DataAccess.Repositories.DisciplineRepositories;
using Quizzando.DataAccess.Repositories.DisciplineRepository;
using Quizzando.DataAccess.Repositories.QuestionRepositories;
using Quizzando.DataAccess.Repositories.UserDisciplineRepositories;
using Quizzando.DataAccess.Repositories.UserRepositories;
using Quizzando.Security.Cryptography;
using Quizzando.Security.Tokens.AccessToken;
using Quizzando.Security.Tokens.RecoverToken;
using Quizzando.UseCases.Users.Register;

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
            services.AddScoped<IUserDisciplineRelationWriteOnlyRepository, UserDisciplineRelationRepository>();
            services.AddScoped<IUserDisciplineRelationReadOnlyRepository, UserDisciplineRelationRepository>();
            services.AddScoped<IQuestionReadOnlyRepository, QuestionRepository>();
            services.AddScoped<IQuestionWriteOnlyRepository, QuestionRepository>();
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
            var signingKey = configuration["Jwt:Key"];
            var expirationTimeMinutes = Convert.ToUInt32(configuration["Jwt:ExpirationMinutes"]);

            services.AddScoped<IAccessTokenGenerator>(config => new AccessTokenGenerator(expirationTimeMinutes, signingKey!));
        }
    }
}
