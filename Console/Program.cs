using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities;
using LogicLib.BackgroundServices;
using LogicLib.Services;
using LogicLib.Services.Impl;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Web_Api;

namespace ConsoleApp1
{
    static class Program
    {
        public static async Task Main(string[] args)
        {

           // var tt = Enumerable.Range(1, 5)
           //     .CumulativeSum(new Monoid<int>(0,(i1,i2)=>i1+i2));
           // Console.WriteLine(tt.Aggregate("",(x1,x2)=>$"{x1},{x2}"));

            var configuration = new ConfigurationBuilder().Build();
            var server = WebHost.CreateDefaultBuilder()
                .UseEnvironment("Production")
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddDebug();
                    logging.AddFilter(x => x >= LogLevel.Debug);
                })
                .UseConfiguration(configuration)
                .UseStartup<Startup>()
                .Build();


            using var scope = server.Services.CreateScope();
            var dalService = scope.ServiceProvider.GetService<IDalService>(); //.CreateUnitOfWork();
            var timeClockService = scope.ServiceProvider.GetService<IEmployeeTimeClockService>(); //.CreateUnitOfWork();
            var list = await (timeClockService as EmployeeTimeClockService)
                .TestGeTimeClocks(DateTimeOffset.Now, DateTimeOffset.Now.AddDays(1), 0, int.MaxValue, null, false);
            Console.WriteLine($"len ={list.Count()}");
            foreach (var x in list)
            {
                Console.WriteLine(x + $"---- {x.Properties?.DictToString()}");
            }
        }

        public static string DictToString<T1, T2>(this Dictionary<T1, T2> dict)
        {
            return dict.Keys.Aggregate("", (current, key) => current + (", "+key + "=" + dict[key]));
        }
        

        
    }
    
  
}