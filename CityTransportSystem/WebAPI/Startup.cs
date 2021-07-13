using Autofac;
using BusinessLogic.Interfaces;
using BusinessLogic.Mappings;
using BusinessLogic.Services;
using DataAccess.EF;
using DataAccess.Repositories;
using DataAccess.UnitOfWork;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using WebAPI.Mappings;
using WebAPI.Validators;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                    {
                        string connectionString = Configuration.GetConnectionString("PostgreSQL");
                        options.UseLazyLoadingProxies();
                        options.UseNpgsql(connectionString);
                    })
                    .AddAutoMapper(map => map.AddMaps(new[] {
                        typeof(TransportDtoMappingConfiguration).Assembly,
                        typeof(TransportViewMappingConfiguration).Assembly
                    }))
                    .AddFluentValidation()
                    .AddValidatorsFromAssemblyContaining<TransportValidator>()
                    .AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterAssemblyTypes(typeof(TransportRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(TransportService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
