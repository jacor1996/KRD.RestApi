using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.DataAccess;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Common.Entities;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace WebApplication
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

            services.AddDbContext<DataContext>(
                dbOptions =>
                    dbOptions.UseSqlServer(Configuration.GetConnectionString("DataConnectionString"),
                        b => b.MigrationsAssembly("Infrastructure")
                        )
            );

            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepository<Package>, Repository<Package>>();
            services.AddScoped<IPackageRepository, PackageRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPackageService, PackageService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
