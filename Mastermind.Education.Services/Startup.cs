using System.Net;
using AutoMapper;
using Mastermind.Education.Services.ApplicationCore.Interfaces;
using Mastermind.Education.Services.ApplicationCore.Services;
using Mastermind.Education.Services.Data;
using Mastermind.Education.Services.Infrastructure.Data.Repository;
using Mastermind.Education.Services.Infrastructure.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mastermind.Education.Services
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
            services.AddAutoMapper();
            services.Configure<EducationSettings>(Configuration);
            services.AddDbContext<EducationContext>(options => options.UseSqlServer(Configuration["ConnectionString"]));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //Services
            services.AddScoped<IEnrollmentService, EnrollmentService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICourseService, CourseService>();

            //Repositories
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseExceptionHandler(
                builder =>
                {
                    builder.Run(
                    async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                        }
                    });
                });
        }
    }
}
