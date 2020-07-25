using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LogicLib.BackgroundServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Web_Api.Installers;
using Web_Api.StartupTasks;

namespace Web_Api
{
    public sealed class Startup
    {
        private readonly ILogger<Startup> _logger;
        private readonly IWebHostEnvironment _currentEnvironment;

        public Startup(IConfiguration configuration, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            _currentEnvironment = env;
            Configuration = configuration;
            _logger = logger;
            _logger.LogInformation($"In {env.EnvironmentName} environment");
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _logger.LogInformation("Enter ConfigureServices");
            services.InstallServicesInAssembly(Configuration, _currentEnvironment, _logger);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _logger.LogInformation("Enter Configure");
            app.InstallConfigurationsInAssembly(env, Configuration, _logger);


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //start startup tasks here
            StartStartupTasks(app, env);
            StartBackgroundServices(app, env);
        }

        private static void StartStartupTasks(IApplicationBuilder app, IWebHostEnvironment env,
            CancellationToken cancellationToken = default,
            params IStartupTask[] tasks)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

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
                    startupTask.ExecuteAsync(cancellationToken).Wait(cancellationToken);
                    logger.LogInformation($"Startup task completed:{startupTask.GetType().Name}");
                }
                catch (Exception error)
                {
                    logger.LogWarning($"Startup task {startupTask.GetType().Name} exit with error: {error.Message}");
                    throw;
                }
            }
        }
        
        
        
        private static void StartBackgroundServices(IApplicationBuilder app, IWebHostEnvironment env,
            CancellationToken cancellationToken = default,
            params IBackgroundService[] tasks)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

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
                    t =>  logger.LogWarning($"Background service exit with error: {t.Exception.Message}")
                    , TaskContinuationOptions.OnlyOnFaulted);
                task.Start();
                logger.LogInformation($"Background service started :{service.GetType().Name}");
            }
        }
    }
}