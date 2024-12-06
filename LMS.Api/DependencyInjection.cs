using Lms.Application;
using Lms.Domain;
using Lms.Infrastructure;

namespace LMS.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLMSDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI()
               .AddInfrastructureDI(configuration)
               .AddDomainDI(configuration);
            return services;
        }
    }
}
