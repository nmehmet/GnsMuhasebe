using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.Infrastructure.Repositrories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GnsMuhasebe.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfraStructureServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}