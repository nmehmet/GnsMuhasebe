using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.Infrastucture.Repositrories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GnsMuhasebe.Infrastucture
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