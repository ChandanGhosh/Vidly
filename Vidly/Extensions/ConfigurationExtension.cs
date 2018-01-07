using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Vidly.Extensions
{
    public static class ConfigurationExtension
    {
        public static IServiceCollection AddPoCoConfig<TConfig>(this IServiceCollection services, IConfiguration configuration)
            where TConfig : class, new()
        {
            services.Configure<TConfig>(configuration);            
            return services.AddScoped<TConfig>(cfg=> cfg.GetService<IOptionsSnapshot<TConfig>>().Value);
           
        }
    }
}