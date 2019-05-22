using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AnalysisTool.Models;
using AnalysisTool.Services;
using AnalysisTool.Persistence;
using AnalysisTool.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using AspNetCore.Identity.MongoDbCore.Models;
using AspNetCore.Identity.MongoDbCore.Infrastructure;
using AspNetCore.Identity.MongoDbCore.Extensions;
using Microsoft.Extensions.Options;

namespace AnalysisTool
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
            // Get the Db Connection String/DB Name
            var settings = Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();

            // Add DB Context to services
            Configuration.Bind(nameof(MongoDbSettings), settings);
            services.AddSingleton(settings);


            // Add Identity Server
            services.AddIdentity<User, Role>()
                    .AddMongoDbStores<User, Role, Guid>(settings.ConnectionString, settings.DatabaseName)
                    .AddDefaultTokenProviders();
            
            // Injection
            
            services.AddTransient<IAssessmentRepository, AssessmentRepository>();
            services.AddTransient<IPrescribedAssessmentRepository, PrescribedAssessmentRepository>();
            services.AddTransient<IAssessmentSessionRepository, AssessmentSessionRepository>();
            services.AddTransient<IAnalysisToolContext, AnalysisToolContext>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();


            // Compatibility
            services.AddMvc();
        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();

                

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Populate the database with seed data
            SeedService.SeedUsers(services);

            // now need to seed the assessments
            SeedService.SeedAssessments(services.GetService<IUnitOfWork>());
        }
    }
}
