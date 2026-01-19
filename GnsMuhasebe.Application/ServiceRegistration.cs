using GnsMuhasebe.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GnsMuhasebe.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddAutoMapper(cfg => { cfg.AddMaps(assembly); });
        }
    }
}
