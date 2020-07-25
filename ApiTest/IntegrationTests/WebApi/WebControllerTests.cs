using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Repositories.Impls.Ral;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Web_Api;
using Xunit;

namespace Tests.IntegrationTests.WebApi
{
    public class WebControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected IDalService DalService { get; }
        protected IMapper Mapper { get; }
        protected TestServer TestServer { get; }
        
        protected readonly RalDbContext DbContext;

        protected WebControllerTests()
        {
            TestServer = new TestServer(
                WebHost.CreateDefaultBuilder()
                    .UseEnvironment("InMemoryTesting")
                    .UseStartup<Startup>());
            
            DbContext = (RalDbContext)TestServer.Host.Services.GetService(typeof(RalDbContext));
            DalService = (IDalService)TestServer.Host.Services.GetService(typeof(IDalService));
            Mapper = (IMapper)TestServer.Host.Services.GetService(typeof(IMapper));
        }
    }
}
