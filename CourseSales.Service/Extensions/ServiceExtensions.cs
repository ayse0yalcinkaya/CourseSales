using CourseSales.Service.Courses;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using CourseSales.Service.ExceptionHandlers;

namespace CourseSales.Service.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICourseService, CourseService>();

            //services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddExceptionHandler<CriticalExceptionHandler>();
            services.AddExceptionHandler<GlobalExceptionHandler>();

            return services;
        }
    }
}
