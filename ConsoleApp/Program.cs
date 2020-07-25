using DataAccessLayer.SAPHandler;
using DataAccessLayer.UnitsOfWorks;
using DataAccessLayer.UnitsOfWorks.SAP;
using DataAccessLayer.Entities;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Web_Api;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using DataAccessLayer.SAPHandler.SqlHandler.Models;
using System.Linq.Expressions;
using DataAccessLayer.Entities.Documents;
using System.Data.SqlClient;
using System.Diagnostics;
using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Entities.BusinessPartners;
using LogicLib.Services;
using DataAccessLayer.UnitsOfWorks.Ral;
using Microsoft.Data.Sqlite;
using DataAccessLayer.Repositories.Impls.Ral;
using Microsoft.Extensions.DependencyInjection;
using DataAccessLayer.Repositories.Impls.SAP;
using Geocoding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Web_Api.DTOs;
using Web_Api.StartupTasks;

namespace ConsoleApp
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
       
            Console.WriteLine(DateTime.Now.ToString("o"));
            var configuration = new ConfigurationBuilder()
                .Build();
            var s = WebHost.CreateDefaultBuilder()
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddDebug();
                    logging.AddFilter(x => x >= LogLevel.Information );
                })
                .UseConfiguration(configuration)
                .UseEnvironment("Staging")
                .UseStartup<Startup>()
                .Build();
            using (var scope = s.Services.CreateScope())
            {
                
                var mapper = (IMapper) scope.ServiceProvider.GetService(typeof(IMapper));

                var dalService = (IDalService) scope.ServiceProvider.GetService(typeof(IDalService));
                var qService = (IQuotationService) scope.ServiceProvider.GetService(typeof(IQuotationService));

               var docNum = (await qService.GetByDocNumberAsync(121041)).Sn.GetValueOrDefault(0);
                await dalService.CreateUnitOfWork().Quotations.CreatePdf(docNum);
                
                                  
                var server = s.RunAsync();

                await server;
            }
        }


        // var dalService = (DalService)s.Services.GetService(typeof(DalService));


        //// SapDiApiContext sapDiApiContext = new SapDiApiContext(configuration.GetConnectionString("SAP-SERVER_DIAPI"));
        // SapSqlDbContext sapSqlDb = new SapSqlDbContext(configuration.GetConnectionString("SAP-SERVER_SQL"));

        // var fromDate = new DateTime(2017, 1, 1);
        // //var rdr = sapSqlDb.ORDR.Where(x => x.CANCELED != "Y" && x.DocDate.Value > fromDate && x.SlpCode == 2).Select(AsSales).GroupBy(x => new { x.Date.Month })
        // //      .Select(x => x.Sum(v => v.Total)).FirstOrDefault();


        //// sapSqlDb.ORDR.Where(x => x.CANCELED != "Y" && x.DocDate.Value > new DateTime(2017, 1, 1) && x.SlpCode == 2).Select(AsSales).GroupBy(x => new { x.Date.Year, x.Date.Month })
        ////.Select(x => x.Sum(v => v.Total)).ToList().ForEach(x => Console.WriteLine($"rdr:{x}"));

        // sapSqlDb.ORDR.Select(AsOrderHeaderEntitiy).Where(x=>x.Date >= new DateTime(2017, 1, 1) && x.SalesmanSN == 2 && x.IsCanceled == false)
        //     .Select(AsSales2).GroupBy(x => new { x.Date.Year, x.Date.Month }).Select(x => x.Sum(v => v.Total)).ToList().ForEach(x => Console.WriteLine($"rdr:{x}"));
    }
}