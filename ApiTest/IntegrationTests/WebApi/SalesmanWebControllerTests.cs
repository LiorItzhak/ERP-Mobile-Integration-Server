using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using FluentAssertions;
using Newtonsoft.Json;
using Web_Api.DTOs;
using Xunit;

namespace Tests.IntegrationTests.WebApi
{
    public class SalesmanWebControllerTests : WebControllerTests ,IDisposable
    {
        List<SalesmanEntity> addedsalesmen;
        public SalesmanWebControllerTests() : base()
        {
            addedsalesmen = allocateDemoSalesmen();
        }

        [Theory]
        [InlineData("/api/salesman/All")]
        public async Task GetAlSalesmen(string url)
        {
            //Given a running server with salesmen allocated in his database 
            DalService.CreateUnitOfWork().Salesmen.GetAllAsync(PageRequest.Of(0,int.MaxValue)).Result.Should().HaveCountGreaterThan(0);

            //When a client ask for URL /api/Salesmen/All
            var client = TestServer.CreateClient();
            var response = await client.GetAsync(url);

            //Then the response will be successful
            response.EnsureSuccessStatusCode(); // Status Code 200-299

            //and the result body should not be null
            var json = await response.Content.ReadAsStringAsync();
            IEnumerable<SalesmanDto> reaultObjects = JsonConvert.DeserializeObject<IEnumerable<SalesmanDto>>(json);
            reaultObjects.Should().NotBeNull();

            //and the result body should match the salesmen in the database
            var allSalesmenFromDb = DalService.CreateUnitOfWork().Salesmen.GetAllAsync(PageRequest.Of(0,int.MaxValue)).Result
                .Select(s => Mapper.Map<SalesmanDto>(s)); ;
            reaultObjects.Should().BeEquivalentTo(allSalesmenFromDb, options => options.IncludingNestedObjects());

        }

        [Theory]
        [InlineData("/api/salesman?page=0&size=3")]
        [InlineData("/api/salesman?page=1&size=3")]
        [InlineData("/api/salesman?page=2&size=2")]
        [InlineData("/api/salesman?page=0&size=300")]
        public async Task GetSalesmenPageing(string url)
        {
            //Given a running server with salesmen allocated in his database 
            DalService.CreateUnitOfWork().Salesmen
                .GetAllAsync(PageRequest.Of(0,int.MaxValue)).Result.Should().HaveCountGreaterThan(0);

            //When a client ask for URL /api/salesman?page=x&size=y
            var client = TestServer.CreateClient();
            var response = await client.GetAsync(url);

            //Then the response will be successful
            response.EnsureSuccessStatusCode(); // Status Code 200-299

            //and the result body should not be null
            var json = await response.Content.ReadAsStringAsync();
            IEnumerable<SalesmanDto> reaultObjects = JsonConvert.DeserializeObject<IEnumerable<SalesmanDto>>(json);
            reaultObjects.Should().NotBeNull();


            //and the result body should contain size or less elements
            var size = Convert.ToInt32(url.Split("size=")[1]);
            var page = Convert.ToInt32(url.Split("page=")[1].Split("&")[0]);
            reaultObjects.Should().HaveCountLessOrEqualTo(size);

            //and the result body should match the salesmen in the database
            var allSalesmenFromDb = DalService.CreateUnitOfWork().Salesmen
                    .GetAllAsync(PageRequest.Of(page,size,Sort<SalesmanEntity>.By(x=>x.Sn))).Result
                .Select(s => Mapper.Map<SalesmanDto>(s));
            reaultObjects.Should().BeEquivalentTo(allSalesmenFromDb, options => options.IncludingNestedObjects());

        }


        [Theory]
        [InlineData("/api/salesman/GetByID/1")]
        [InlineData("/api/salesman/GetByID/2")]
        [InlineData("/api/salesman/GetByID/3")]
        public async Task GetSalesmanByID(string url)
        {
            //Given a running server with employees allocated in his database 
            var salesmanId = Convert.ToInt32(url.Split("GetByID/")[1]);
            var salesmanFromDb = DalService.CreateUnitOfWork().Salesmen.FindByIdAsync(salesmanId).Result;
            salesmanFromDb.Should().NotBeNull();

            //When a client ask for URL /api/salesman/GetByID/5
            var client = TestServer.CreateClient();
            var response = await client.GetAsync(url);


            //Then the response will be successful
            response.EnsureSuccessStatusCode(); // Status Code 200-299

            //and the result body should not be null
            var json = await response.Content.ReadAsStringAsync();
            SalesmanDto reaultObject = JsonConvert.DeserializeObject<SalesmanDto>(json);
            reaultObject.Should().NotBeNull();

            //and the result body should match the salesman in the database
            reaultObject.Should().BeEquivalentTo(Mapper.Map<SalesmanDto>(salesmanFromDb)
                , options => options.IncludingNestedObjects());

        }
        private List<SalesmanEntity> allocateDemoSalesmen(string name = "TestSalesman", int count = 10)
        {
            var e = Enumerable.Range(1, count).ToList()
              .Select(i =>
               DbContext.Salesmen.Add(new SalesmanEntity
               {
                   Name = name + ":" + i
               }).Entity).ToList();
            DbContext.SaveChanges();
            return e;
        }

        public void Dispose()
        {
            if (addedsalesmen != null)
                DbContext.Salesmen.RemoveRange(addedsalesmen);
        }
    }


}
