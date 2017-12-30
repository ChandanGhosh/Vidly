using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Vidly.Services
{
    public static class EnvironmentServiceExtensions
    {
        public static void AddEnvironmentServiceConfigurations(this IServiceCollection serviceCollection,
            IHostingEnvironment environment) => new EnvironmentService(environment);
    }
}