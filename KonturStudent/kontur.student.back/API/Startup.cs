using System;
using System.IO;
using System.Text.Json.Serialization;
using API.Models;
using API.Services;
using API.Services.Interfaces;
using API.Utils;
using IdentityModel.AspNetCore.OAuth2Introspection;
using KSRepositories.Db;
using KSRepositories.DbModels;
using KSRepositories.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vostok.Logging.Abstractions;
using Vostok.ServiceDiscovery.Kontur;

namespace API
{
    public class Startup
    {
        private const string SwaggerTitleName = "Контур.Студент API";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin",
                    options => options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

            services.Configure<About>(Configuration.GetSection("About"));
            
            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<KonturStudentDbContext>();

            services.AddStaffClient();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ProjectRepository>();
            services.AddScoped<TechnologyRepository>();
            services.AddScoped<MentorRepository>();

            services.AddScoped<ICourseStatusService, CourseStatusService>();
            services.AddScoped<IProjectsService, ProjectsService>();
            services.AddScoped<IStaffService, StaffService>();
            services.AddScoped<ITechnologiesService, TechnologiesService>();
            services.AddScoped<AbstractRepository<User>, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            
            services.AddControllers()
                .AddJsonOptions(opts =>
                {
                    opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.AddOpenApiDocument(c =>
            {
                c.Title = SwaggerTitleName;
                c.DocumentName = "v1";
                c.Version = "v1";
            });

            services
                .AddAuthentication(OAuth2IntrospectionDefaults.AuthenticationScheme)
                .AddOAuth2Introspection(options =>
                {
                    options.Authority = "https://identity.testkontur.ru";
                    options.ClientId = Configuration["Authentication:ClientId"];
                    options.ClientSecret = Configuration["Authentication:ClientSecret"];
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(
                async (context, next) =>
                {
                    if (!context.Request.Path.StartsWithSegments("/api")
                        && string.IsNullOrEmpty(Path.GetExtension(context.Request.Path)))
                    {
                        // Use default page for SPA
                        context.Request.Path = "/index.html";
                    }

                    context.Request.Path = context.Request.Path.Value?.Replace("/api/", "/");

                    await next();
                });
            
            app.UseStaticFiles();

            app.UseDeveloperExceptionPage();
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigureServiceBeacon(app);
        }

        private void ConfigureServiceBeacon(IApplicationBuilder app)
        {
            var log = app.ApplicationServices.GetService<ILog>();

            var serviceBeacon = ServiceBeaconProvider.Get(
                replicaInfoBuilder => replicaInfoBuilder
                    .SetEnvironment("default")
                    .SetApplication("KonturStudent")
                    .SetPort(1234),
                log: log);

            serviceBeacon.Start();
        }
    }
}