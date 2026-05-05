using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.Core.Database.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddErpDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            

            return services;
        }
    }
}