using AutoMapper;
using DataAccessLayer.Repositories.Impls.Ral;
using LogicLib.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper.Configuration;
using DataAccessLayer;
using Web_Api;

namespace Tests.ServicesTests
{
    public abstract class BaseServicesTest
    {
        protected readonly IDalService DalService;
        protected readonly IMapper Mapper;

        protected readonly TestServer TestServer;
        protected readonly RalDbContext DbContext;

        public BaseServicesTest()
        {
            TestServer = new TestServer(
                WebHost
                    .CreateDefaultBuilder()
                    .UseEnvironment("InMemoryTesting")
                    .UseStartup<Startup>());
            
            var configuration =(IConfiguration) TestServer.Host.Services.GetService(typeof(IConfiguration));

            DbContext = (RalDbContext) TestServer.Host.Services.GetService(typeof(RalDbContext));
            DalService = (IDalService) TestServer.Host.Services.GetService(typeof(IDalService));
            Mapper = (IMapper) TestServer.Host.Services.GetService(typeof(IMapper));
        }

        public Service GetServiceProvider<Service>()
        {
            return (Service) TestServer.Host.Services.GetService(typeof(Service));
        }
    }
}