using System;
using System.Linq;
using Geocoding;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Web_Api.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration,
            IWebHostEnvironment env, ILogger logger)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes
                .Where(x => typeof(IServiceInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Where(x => x.GetCustomAttributes(typeof(ProfileAttribute), true)
                    .Select(a => a as ProfileAttribute)
                    .All(a => a != null && a.Profiles.Contains(env.EnvironmentName)))
                .Select(Activator.CreateInstance).Cast<IServiceInstaller>().ToList();

            var installersStr = installers.Select(x => x.GetType().Name).Aggregate((x1, x2) => $"{x1},{x2}");
            logger.LogInformation($"ServiceInstaller collected: {installersStr}");
            installers.ForEach(x => x.InstallServices(services, configuration, env, logger));
        }

        public static void InstallConfigurationsInAssembly(this IApplicationBuilder app, IWebHostEnvironment env,
            IConfiguration configuration, ILogger logger)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes
                .Where(x => typeof(IConfigurationInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Where(x => x.GetCustomAttributes(typeof(ProfileAttribute), true)
                    .Select(a => a as ProfileAttribute)
                    .All(a => a != null && a.Profiles.Contains(env.EnvironmentName)))
                .Select(Activator.CreateInstance).Cast<IConfigurationInstaller>().ToList();

            var installersStr = installers.Select(x => x.GetType().Name).Aggregate((x1, x2) => $"{x1},{x2}");
            logger.LogInformation($"ConfigurationInstaller collected: {installersStr}");
            installers.ForEach(x =>  x.InstallConfiguration(app, env, configuration, logger));
        }
    }
}