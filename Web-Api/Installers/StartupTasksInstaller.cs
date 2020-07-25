using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Web_Api.StartupTasks;

namespace Web_Api.Installers
{
    [Profile("Development","InMemoryTesting")]
    public class DevStartupTasksInstaller:IServiceInstaller
    {
        
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env,ILogger logger)
        {
            services.AddScoped<IStartupTask,MockDbAllocatorStartup>();
        }
    }
    
    [Profile("Staging","Production")]
    public class StartupTasksInstaller:IServiceInstaller
    {
        
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env,ILogger logger)
        {
              services.AddScoped<IStartupTask,AddUsersStartupTask>();
        }
    }
}