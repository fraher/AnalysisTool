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
using Microsoft.EntityFrameworkCore;
using AnalysisTool.Services;
using AnalysisTool.Persistence;
using AnalysisTool.Persistence.Repositories;

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
            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.Configure<Settings>(options =>
            {
                options.ConnectionString
                    = Configuration.GetSection("ConnectionStrings:AnalysisToolDb").Value;
                options.Database
                    = Configuration.GetSection("ConnectionStrings:DatabaseName").Value;
            });

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAssessmentRepository, AssessmentRepository>();
            services.AddTransient<IPrescribedAssessmentRepository, PrescribedAssessmentRepository>();
            services.AddTransient<IAssessmentSessionRepository, AssessmentSessionRepository>();
            services.AddTransient<IAnalysisToolContext, AnalysisToolContext>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            

        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Populate the database with seed data
            
            SeedService.Seed(app.ApplicationServices);
        }
    }
}
