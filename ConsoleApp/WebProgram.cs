//using DataAccessLayer.SAPHandler;
//using DataAccessLayer.UnitsOfWorks;
//using DataAccessLayer.UnitsOfWorks.SAP;
//using DataAccessLayer.Entities;
//using System;
//using System.Linq;
//using Microsoft.Extensions.Configuration;
//using Microsoft.AspNetCore;
//using Microsoft.AspNetCore.Hosting;
//using Web_Api;
//
//using Microsoft.Extensions.Logging;
//using RandomNameGeneratorLibrary;
//using Bogus.Extensions.UnitedStates;
//using Web_Api.Utils;
//
//namespace ConsoleApp
//{
//    public class WebProgram
//    {
//        public static  void Main(string[] args)
//        {
//            var server = CreateWebHostBuilder(args).Build();
//           // server.StartBackgroundServices(); 
//            server.RunAsync().Wait();
//        }
//
//        
//        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
//            WebHost.CreateDefaultBuilder(args)
//                .ConfigureLogging((hostingContext, logging) =>
//                {
//                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
//                    logging.AddConsole();
//                    logging.AddDebug();
//                    logging.AddEventSourceLogger();
//                })
//                .UseStartup<SapStartup>();
//        
//        
//        //.UseStartup<InMemoryStartup>();
//    }
//}
