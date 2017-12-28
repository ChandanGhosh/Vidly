using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebEssentials.AspNetCore.Pwa;

namespace Vidly
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            
            // The below two lines enable your app to be a PWA!
            // you will also have access to the manifest.json peoperties as well as dependency injected in other
            // areas as ManifestSettings
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddProgressiveWebApp(new PwaOptions()
            {
                RoutesToPreCache = "/",
                Strategy = ServiceWorkerStrategy.CacheFirst
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
