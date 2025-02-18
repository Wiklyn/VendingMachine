using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VendingMachine.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
