using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test.Domain.Services;

namespace Test.Domain
{
    public static class ServiceMap
    {
        public static IServiceCollection AddModuleServices(this IServiceCollection services, IConfiguration configuration)
        {
            foreach (var type in typeof(ServiceMap).Assembly.GetTypes()
                         .Where(type => !type.IsInterface &&
                                        !type.IsAbstract &&
                                        !type.IsGenericTypeDefinition &&
                                        typeof(IModuleService).IsAssignableFrom(type)))
            {
                services.AddTransient(type);
            }

            return services;
        }
    }
}