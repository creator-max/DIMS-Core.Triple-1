using System.Collections.Generic;
using System.Reflection;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Services;
using DIMS_Core.DataAccessLayer.Extensions;
using DIMS_Core.Identity.Extensions;
using DIMS_Core.Mailer.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DIMS_Core.BusinessLayer.Extensions
{
    public static class MiddlewareServiceExtensions
    {
        public static IServiceCollection AddDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<ISampleService, SampleService>();
            services.AddScoped<IUserService, UserService>();

            services.AddDatabaseDependencies()
                    .AddIdentityDependencies()
                    .AddMailerDependencies();

            return services;
        }

        public static IServiceCollection AddAutomapperProfiles(this IServiceCollection services, params Assembly[] otherMapperAssemblies)
        {
            services.AddAutoMapper(new List<Assembly>(otherMapperAssemblies)
                                   {
                                       Assembly.GetExecutingAssembly()
                                   });

            return services;
        }

        public static IServiceCollection AddCustomSolutionConfigs(this IServiceCollection services,
                                                                  IConfiguration configuration,
                                                                  params Assembly[] otherMapperAssemblies)
        {
            services.AddDependencyInjections()
                    .AddDatabaseContext(configuration)
                    .AddAutomapperProfiles(otherMapperAssemblies)
                    .AddIdentityContext();

            return services;
        }
    }
}