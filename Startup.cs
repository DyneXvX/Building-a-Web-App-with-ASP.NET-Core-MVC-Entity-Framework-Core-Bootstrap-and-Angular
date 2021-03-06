using DutchTreat.Data;
using DutchTreat.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DutchTreat
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DutchContext>(cfg => { cfg.UseSqlServer(_config.GetConnectionString("DutchConnectionString")); });
            //support for the database
            services.AddTransient<DutchSeeder>();
            services.AddTransient<IMailService, NullMailService>();
            //support for a real mail service <-- At some point.
            services.AddControllersWithViews();
            services.AddRazorPages(); //required for razor pages -- error page in this case
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                //add error page
                app.UseExceptionHandler("/error");

            //app.UseDefaultFiles();          //finds the index and runs it as default without the localhost:8888/index.html
            app.UseStaticFiles(); //only use static files from the wwwroot directory. 
            //app.UseNodeModules();

            app.UseRouting();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute("Fallback",
                    "{controller}/{action}/{id?}",
                    new {controller = "App", action = "Index"});
                cfg.MapRazorPages(); //required for razor pages --error page in this case
            }); //creates the routes we are going to use. Needs the services.AddContorllersWithViews(); to work correctly.
        }
    }
}