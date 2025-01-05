using CourseSales.Repositories.Categories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CourseSales.Repositories.Courses;
using CourseSales.Repositories.Interceptors;
using CourseSales.Repositories.Users;
using CourseSales.Repositories.Users.CourseSales.Repositories.Users;

namespace CourseSales.Repositories.Extensions
{
    public static class RepositoryExtentions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CourseSalesDbContext>(options =>
            {
                var connectionStrings = configuration.GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();
                options.UseSqlServer(connectionStrings!.SqlServer, sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.FullName);
                });

                options.AddInterceptors(new AuditDbContextInterceptor());
            });

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped(typeof(IGenericRepository<,>),typeof(GenericRepository<,>));
            //services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}