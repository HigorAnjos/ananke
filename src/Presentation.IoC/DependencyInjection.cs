using Ananke.Application.Mappings;
using Ananke.Application.Services;
using Ananke.Domain.IServices;
using Ananke.Domain.Repository;
using Ananke.Infra.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IScrapingRepository, ScrapingRepository>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
