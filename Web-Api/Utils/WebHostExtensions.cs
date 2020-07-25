using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Repositories.Impls.Ral;
using LogicLib.BackgroundServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Web_Api.StartupTasks;

namespace Web_Api.Utils
{
    public static class WebHostExtensions
    {
        public static async Task RunWithStartupTasksAsync(this IWebHost webHost,
            CancellationToken cancellationToken = default, params IStartupTask[] tasks)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                // Load all tasks from DI
                var startupTasks = scope.ServiceProvider.GetServices<IStartupTask>();
                var logger = scope.ServiceProvider.GetService<ILogger<Program>>();

                if (tasks != null)
                    startupTasks = startupTasks.Union(tasks);

                // Execute all the tasks
                foreach (var startupTask in startupTasks)
                {
                    logger.LogInformation($"Startup task started :{startupTask.GetType().Name}");
                    try
                    {
                        await startupTask.ExecuteAsync(cancellationToken);
                        logger.LogInformation($"Startup task completed:{startupTask.GetType().Name}");
                    }
                    catch (Exception error)
                    {
                       logger.LogWarning($"Startup task {startupTask.GetType().Name} exit with error: {error.Message}");
                       throw;
                    }
                    
                }
            }

            // Start the server as normal
            await webHost.RunAsync(cancellationToken);
        }

        public static IWebHost StartBackgroundServices(this IWebHost webHost,
            CancellationToken cancellationToken = default, params IBackgroundService[] tasks)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                // Load all tasks from DI
                var backgroundServices = scope.ServiceProvider.GetServices<IBackgroundService>();
                var logger = scope.ServiceProvider.GetService<ILogger<Program>>();
                if (tasks != null)
                    backgroundServices = backgroundServices.Union(tasks);

                // Execute all the background services
                foreach (var service in backgroundServices)
                {
                    var task = service.GetTask(cancellationToken);
                    task.ContinueWith(
                        t => logger.LogWarning($"Background service exit with error: {t.Exception.Message}")
                        , TaskContinuationOptions.OnlyOnFaulted);
                    task.Start();
                    logger.LogInformation($"Background service started :{service.GetType().Name}");
                }
            }

            return webHost;
        }
    }
}