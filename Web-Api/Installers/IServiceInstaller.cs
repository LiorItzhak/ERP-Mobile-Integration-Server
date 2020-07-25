using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Web_Api.Installers
{
    public interface IServiceInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env,ILogger logger);
    }
    
    public interface IConfigurationInstaller
    {
        void InstallConfiguration(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration,ILogger logger);
    }
}