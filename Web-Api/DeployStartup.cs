using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Repositories.Impls.Ral;
using DataAccessLayer.SAPHandler;
using DataAccessLayer.SAPHandler.SqlHandler.Models;
using DataAccessLayer.UnitsOfWorks;
using DataAccessLayer.UnitsOfWorks.SAP;
using LogicLib.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Web_Api
{
    public class DeployStartup : Startup
    {
        public DeployStartup(IConfiguration configuration, ILogger<DeployStartup> logger) : base(configuration, logger)
        {
        }



        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            Logger.LogInformation("Added  SAP Deployment servers to services");
            
            services.AddSingleton(new SapContextOptions
            {
                SqlServerConnection = Configuration.GetConnectionString("CM-SAP-SERVER_SQL"),
                 DiApiServerConnection = Configuration.GetConnectionString("CM-SAP-SERVER_DIAPI"),

                SapSqlServerOptions = new DbContextOptionsBuilder<SapSqlDbContext>()
                    .UseSqlServer(Configuration.GetConnectionString("CM-SAP-SERVER_SQL")).Options,
                
                ExtrasServerOptions = new DbContextOptionsBuilder<RalDbContext>()
                    .UseSqlServer(Configuration.GetConnectionString("SapExtra-SERVER_SQL")).Options

            });

            services.AddTransient<IUnitOfWork, SapUnitOfWork>();
            services.AddTransient<DalService, DalService>();
            
        }
    }
}
