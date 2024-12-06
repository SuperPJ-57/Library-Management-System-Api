using Lms.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
namespace Lms.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
