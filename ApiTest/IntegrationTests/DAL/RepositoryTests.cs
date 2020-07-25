using DataAccessLayer.SAPHandler;
using DataAccessLayer.UnitsOfWorks;
using DataAccessLayer.UnitsOfWorks.SAP;
using FluentAssertions;
using DataAccessLayer.Entities;
using System;
using Web_Api.DTOs;
using Xunit;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Web_Api;
using System.Reflection;
using System.IO;
using DataAccessLayer;
using Xunit.Abstractions;
using LogicLib.Services;
using Web_Api.Configuration;

namespace Tests.IntegrationTests.DAL
{
    [Collection("Database collection Backup and Restore")]
    public class RepositoryTests
    {
        protected readonly IDalService DalService;

        protected RepositoryTests(DatabaseFixture fixture)
        {
            var webHost = WebHost.CreateDefaultBuilder()
                .UseEnvironment("SapIntegrationTesting")
                .UseStartup<Startup>()
                .Build();

            var configuration =(IConfiguration) webHost.Services.GetService(typeof(IConfiguration));
            var settings = new TestSettings();
            configuration.Bind(nameof(TestSettings), settings);
            var sapServerSettings = new SapServerSettings();
            configuration.Bind(nameof(SapServerSettings), sapServerSettings);
            fixture.SetBackupPath(settings.SqlBackupPath);
            
            DalService = (IDalService)webHost.Services.GetService(typeof(IDalService));
            
            //Clear tests after dispose
            fixture.SetConnectionString(sapServerSettings.SapServerSql);
            fixture.BackupDatabase();
            fixture.RestoreDatabaseOnDispose(true);
        }


    }
}
