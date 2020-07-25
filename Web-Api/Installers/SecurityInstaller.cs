using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Web_Api.Installers
{
    public class SecurityInstaller : IServiceInstaller, IConfigurationInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env,ILogger logger)
        {
            
            services.Configure<IdentityOptions>(options =>
            {
                //TODO - move to configuration file
                // Password settings 
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                
                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            });
        }

        public void InstallConfiguration(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration,ILogger logger)
        {
        }
    }
}