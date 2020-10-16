using DataAccessLayer;
using DataAccessLayer.Repositories.Impls.Ral;
using DataAccessLayer.SAPHandler;
using DataAccessLayer.SAPHandler.SqlHandler.DbContexts;
using DataAccessLayer.SAPHandler.SqlHandler.Models;
using DataAccessLayer.UnitsOfWorks;
using DataAccessLayer.UnitsOfWorks.Ral;
using DataAccessLayer.UnitsOfWorks.SAP;
using LogicLib.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Web_Api.Configuration;
using IdentityUser = DataAccessLayer.Entities.Authentication.IdentityUser;

namespace Web_Api.Installers
{
    [Profile("Production","ProductionNoAuth", "Staging","SapIntegrationTesting")]
    public class SapDatabaseInstaller : IServiceInstaller, IConfigurationInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env,
            ILogger logger)
        {
            var sapServerSettings = new SapServerSettings();
            configuration.Bind(nameof(SapServerSettings), sapServerSettings);
            var sapContextOptions = new SapContextOptions
            {
                DiApiServerConnection = sapServerSettings.SapServerDiAPi,
                SapSqlServerOptions = new DbContextOptionsBuilder<SapSqlDbContext>()
                    .UseSqlServer(sapServerSettings.SapServerSql)
                    // .EnableSensitiveDataLogging()
                    .Options,
                ExtrasServerOptions = new DbContextOptionsBuilder<RalDbContext>()
                    .UseSqlServer(sapServerSettings.IamServerSql)
                    //  .EnableSensitiveDataLogging()
                    .Options
            };
            services.AddSingleton(sapContextOptions);

            services.AddSingleton<IUnitOfWork, SapUnitOfWork>();
            SapUnitOfWork.CurrentProvider = services.BuildServiceProvider();
            services.AddSingleton<IDalService, DalService>();

            //for migration and identity
            services.AddDbContext<RalDbContext>(builder => builder
                .UseSqlServer(sapServerSettings.IamServerSql)
                .EnableSensitiveDataLogging());

            services.AddIdentityCore<IdentityUser>()
                .AddEntityFrameworkStores<RalDbContext>() 
                .AddDefaultTokenProviders();
        }

        public void InstallConfiguration(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration,
            ILogger logger)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var connOpts = serviceScope.ServiceProvider.GetService<SapContextOptions>();
            var dbContext = new RalDbContext(connOpts.ExtrasServerOptions);
            // dbContext.Database.OpenConnection(); 
            // dbContext.Database.EnsureDeleted();
            // dbContext.Database.Migrate(); 
            // dbContext.Database.EnsureCreated();
        }
    }

    [Profile("Development","InMemoryTesting")]
    public class InMemoryDatabaseInstaller : IServiceInstaller, IConfigurationInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env,
            ILogger logger)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder {DataSource = ":memory:"};
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            services.AddScoped<IDalService, DalService>();
            services.AddScoped<IUnitOfWork, RalUnitOfWork>();
            services.AddDbContext<RalDbContext>(options => options.UseSqlite(connection).EnableSensitiveDataLogging());

            //for migration and identity
            services.AddDbContext<RalDbContext>(builder => builder
                    .UseSqlite(connection)
                    .EnableSensitiveDataLogging());

            services.AddIdentityCore<IdentityUser>()
                .AddEntityFrameworkStores<RalDbContext>();
            
        }

        public void InstallConfiguration(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration,
            ILogger logger)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            serviceScope.ServiceProvider.GetService<RalDbContext>().Database.OpenConnection();
            serviceScope.ServiceProvider.GetService<RalDbContext>().Database.EnsureCreated();
        }
    }
}