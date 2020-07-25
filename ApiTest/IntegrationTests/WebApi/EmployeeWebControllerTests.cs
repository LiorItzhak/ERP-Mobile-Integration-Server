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
    public class EmployeeWebControllerTests : WebControllerTests, IDisposable
    {
        List<EmployeeEntity> addedEmployees;
        public EmployeeWebControllerTests() : base()
        {
            addedEmployees = allocateDemoEmployees();
        }

        //[Theory]
        //[InlineData("/api/Employee/All")]
        public async Task GetAllEmployees(string url)
        {
            //Given a running server with employees allocated in his database 
            DalService.CreateUnitOfWork().Employees.GetAllAsync(PageRequest.Of(0,int.MaxValue)).Result.Should().HaveCountGreaterThan(0);

            //When a client ask for URL /api/Employee/All
            var client = TestServer.CreateClient();
            var response = await client.GetAsync(url);

            //Then the response will be successful
            response.EnsureSuccessStatusCode(); // Status Code 200-299

            //and the result body should not be null
            var json = await response.Content.ReadAsStringAsync();
            IEnumerable<EmployeeDto> reaultObjects = JsonConvert.DeserializeObject<IEnumerable<EmployeeDto>>(json);
            reaultObjects.Should().NotBeNull();

            //and the result body should match the employees in the database
            var allEmployeesFromDb = DalService.CreateUnitOfWork().Employees.GetAllAsync(PageRequest.Of(0,int.MaxValue)).Result
                .Select(e => Mapper.Map<EmployeeDto>(e)); ;
            reaultObjects.Should().BeEquivalentTo(allEmployeesFromDb, options => options.IncludingNestedObjects());

        }

        [Theory]
        [InlineData("/api/Employee?page=0&size=3")]
        [InlineData("/api/Employee?page=1&size=3")]
        [InlineData("/api/Employee?page=2&size=2")]
        [InlineData("/api/Employee?page=0&size=300")]
        public async Task GetEmployeesPageing(string url)
        {
            //Given a running server with employees allocated in his database 
            DalService.CreateUnitOfWork().Employees.GetAllAsync(PageRequest.Of(0,int.MaxValue)).Result.Should().HaveCountGreaterThan(0);

            //When a client ask for URL /api/Employee&page=x&size=y
            var client = TestServer.CreateClient();
            var response = await client.GetAsync(url);

            //Then the response will be successful
            response.EnsureSuccessStatusCode(); // Status Code 200-299

            //and the result body should not be null
            var json = await response.Content.ReadAsStringAsync();
            IEnumerable<EmployeeDto> reaultObjects = JsonConvert.DeserializeObject<IEnumerable<EmployeeDto>>(json);
            reaultObjects.Should().NotBeNull();


            //and the result body should contain size or less elements
            var size = Convert.ToInt32(url.Split("size=")[1]);
            var page = Convert.ToInt32(url.Split("page=")[1].Split("&")[0]);
            reaultObjects.Should().HaveCountLessOrEqualTo(size);

            //and the result body should match the employees in the database
            var allEmployeesFromDb = DalService.CreateUnitOfWork()
                    .Employees.GetAllAsync( PageRequest.Of(page,size,Sort<EmployeeEntity>.By(x=>x.Sn))).Result
                .Select(e => Mapper.Map<EmployeeDto>(e));
            reaultObjects.Should().BeEquivalentTo(allEmployeesFromDb, options => options.IncludingNestedObjects());

        }


        [Theory]
        [InlineData("/api/Employee/GetBySN/1")]
        [InlineData("/api/Employee/GetBySN/2")]
        [InlineData("/api/Employee/GetBySN/5")]
        [InlineData("/api/Employee/GetBySN/3")]
        public async Task GetEmployeeBySn(string url)
        {
            //Given a running server with employees allocated in his database 
            var employeeId = Convert.ToInt32(url.Split("GetBySN/")[1]);
            var employeeFromDb = DalService.CreateUnitOfWork().Employees.FindByIdAsync(employeeId).Result;
            employeeFromDb.Should().NotBeNull();

            //When a client ask for URL /api/Employee/GetByID/5
            var client = TestServer.CreateClient();
            var response = await client.GetAsync(url);


            //Then the response will be successful
            response.EnsureSuccessStatusCode(); // Status Code 200-299

            //and the result body should not be null
            var json = await response.Content.ReadAsStringAsync();
            EmployeeDto reaultObject = JsonConvert.DeserializeObject<EmployeeDto>(json);
            reaultObject.Should().NotBeNull();

            //and the result body should match the employees in the database
            reaultObject.Should().BeEquivalentTo(Mapper.Map<EmployeeDto>(employeeFromDb)
                , options => options.IncludingNestedObjects());

        }



        private List<EmployeeEntity> allocateDemoEmployees(string name = "TestEmployee", int count =10)
        {
           var e =  Enumerable.Range(1, count).ToList()
             .Select(i =>
              DbContext.Employees.Add(new EmployeeEntity
              {
                  FirstName = name + ":" + i
              }).Entity).ToList();
            DbContext.SaveChangesAsync().Wait();
            return e;
        }

        public void Dispose()
        {
            if (addedEmployees != null)
                DbContext.Employees.RemoveRange(addedEmployees);
        }

    }
}
