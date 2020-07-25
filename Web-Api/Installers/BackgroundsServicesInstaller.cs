using System;
using LogicLib.BackgroundServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Web_Api.Installers
{
    [Profile("Production","Staging")]
    public class BackgroundsServicesInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env,ILogger logger)
        {
            services.AddScoped<IBackgroundService, BusinessPartnerLocationBackgroundService>();
        }
    }
}