using AspNetCore.ServiceRegistration.Dynamic.Extensions;
using AspNetCore.ServiceRegistration.Dynamic.Interfaces;
using AutoMapper;
using EmployeeManagement.Api.Utilities.Mixed;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TanvirArjel.EFCore.GenericRepository;

namespace EmployeeManagement.Api
{
    public class Startup
    {
        public Startup(IWebHostEnvironment evn, IConfiguration configuration)
        {
            HostEnvironment = evn;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment HostEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (HostEnvironment.EnvironmentName == "Development")
            {
                services.AddDbContextPool<EmployeeManagementDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("EmployeeDbConnectionLocal"));
                });
            }
            else
            {
                services.AddDbContextPool<EmployeeManagementDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("EmployeeDbConnectionAzure"));
                });
            }

            services.AddGenericRepository<EmployeeManagementDbContext>();

            services.AddAutoMapper(typeof(Startup));
            services.AddServicesOfType<IScopedService>();
            services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
            });

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("AzureRedisCache"); //Configuration["Data:ConectionStrings:AzureRedisCache"];
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Student Management", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1204:Static elements should appear before instance elements", Justification = "Not appplicable here")]
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "My API v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
