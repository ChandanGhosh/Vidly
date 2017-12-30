using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Vidly.Persistance;
using Vidly.Services;
using WebEssentials.AspNetCore.Pwa;

namespace Vidly
{
    public class Startup
    {
        private readonly IHostingEnvironment _environment;

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            _environment = environment;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            
            services.AddMvc();

            services.AddEnvironmentServiceConfigurations(_environment);

            services.AddDbContext<ApplicationDbContext>(dbcontextoptions =>
            {
                dbcontextoptions.UseSqlServer(Configuration.GetConnectionString("Default"));
            });


            // The below two lines enable your app to be a PWA!
            // you will also have access to the manifest.json peoperties as well as dependency injected in other
            // areas as ManifestSettings
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddProgressiveWebApp(new PwaOptions()
            {
//                RoutesToPreCache = "/",
//                Stra
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFilesWithCache(TimeSpan.FromSeconds(2));

            app.UseMvc(routes =>
            {
                //better way of doing this in attribute routing because of magic string in controller and action name. If later the Controller
                // name or action name changes this below routing will break.
                //routes.MapRoute(
                //    name: "MovieByReleaseDateRoute",
                //    template: "{controller=Movies}/{action=Released}/{year}/{month}",
                //    defaults: null,
                //    constraints: new {year = @"\d{4}", month = @"\d{2}" } //year="2016|2017" only expose 2016 or 2017
                //);


                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
