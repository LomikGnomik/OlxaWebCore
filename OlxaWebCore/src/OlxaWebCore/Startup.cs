using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OlxaWebCore.Data;
using OlxaWebCore.Models;
using OlxaWebCore.Services;
using OlxaWebCore.Models.Interfaces;
using OlxaWebCore.Models.RepositoryFake;
using OlxaWebCore.Models.Repository;

namespace OlxaWebCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddTransient<IPortfolioRepository, EFPortfolioRepository>();
            services.AddTransient<IBlogRepository, EFBlogRepository>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddTransient<IServiceRepository, EFServiceRepository>();
            services.AddTransient<IProductRepository, EFProductRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();  // отключить при развёртывании
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //обработка ошибок http
            app.UseStatusCodePagesWithReExecute("/errors/{0}.html"); 

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes => {
                routes.MapRoute(name: "Error", template: "Error",
                    defaults: new { controller = "Error", action = "Error" });

                //routes.MapRoute(
                //    name: null,
                //    template: "{category}/Page{page:int}",
                //    defaults: new { controller = "Blog", action = "AllPosts" }
                //);

                //routes.MapRoute(
                //    name: null,
                //    template: "Page{page:int}",
                //    defaults: new { controller = "Blog", action = "AllPosts", page = 1 }
                //);

                //routes.MapRoute(
                //    name: null,
                //    template: "{category}",
                //    defaults: new { controller = "Blog", action = "AllPosts", page = 1 }
                //);

                //routes.MapRoute(
                //    name: null,
                //    template: "",
                //    defaults: new { controller = "Home", action = "AllPosts", page = 1 });
                

                routes.MapRoute(name: null, template: "{controller}/{action}/{category?}/{id?}", defaults: new { controller = "Home", action = "Index"});
                
        });
            // SeedData.EnsurePopulated(app) ; // заполняет бд начальными значениями(самого класса нет.В книге фримана на стр220)

        }
    }
}
