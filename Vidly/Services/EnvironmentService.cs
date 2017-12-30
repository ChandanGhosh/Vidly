using Microsoft.AspNetCore.Hosting;

namespace Vidly.Services
{
    public class EnvironmentService
    {
        private static IHostingEnvironment _environment;

        public EnvironmentService(IHostingEnvironment environment)
        {
            _environment = environment;
        }


        public static bool IsDevelopmentEnvironment()
        {
            return _environment.IsDevelopment();
        }
    }
}