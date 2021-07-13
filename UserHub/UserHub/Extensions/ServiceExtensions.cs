using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using uh.Entities.Context;
using uh.Repositories.Contracts;
using uh.Repositories.Repositories;
using uh.Services.Contracts;
using uh.Services.Services;

namespace UserHub.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                    );
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }

        public static void ConfigureSqlDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString));
        }

        public static void ConfigureDependency(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IUserDetailsService, UserDetailsService>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            var contact = new OpenApiContact()
            {
                Name = "Romil",
                Email = "chandragade.romil@gmail.com"
                
            };

            var license = new OpenApiLicense()
            {
                Name = "My License"
                
            };

            var info = new OpenApiInfo()
            {
                Version = "v1",
                Title = "Users API",
                Description = "Users API Description",
                TermsOfService = new Uri("http://www.example.com"),
                Contact = contact,
                License = license
            };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", info);
            });
        }
    }
}
