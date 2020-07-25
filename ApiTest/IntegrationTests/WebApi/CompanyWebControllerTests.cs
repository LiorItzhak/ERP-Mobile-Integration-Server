using System;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using FluentAssertions;
using Newtonsoft.Json;
using Web_Api.DTOs;
using Xunit;

namespace Tests.IntegrationTests.WebApi
{
    public class CompanyWebControllerTests : WebControllerTests,IDisposable
    {
        CompanyEntity addedCompany;
        public CompanyWebControllerTests() : base()
        {
            //add mock company
            addedCompany = DbContext.Companies.Add(new CompanyEntity
            {
                Name = "mockTestCompany",
                DefaultCurrency = "ILS"
            }).Entity;
            DbContext.SaveChanges();
        }


        [Theory]
        [InlineData("/api/Company")]
        public async Task GetCompany(string url)
        {
            //Given a running server with company allocated in his database 
            var companyFromDb = DalService.CreateUnitOfWork().Company.GetAsync().Result;
            companyFromDb.Should().NotBeNull();

            //When a client ask for URL /api/Company
            var client = TestServer.CreateClient();
            var response = await client.GetAsync(url);


            //Then the response will be successful
            response.EnsureSuccessStatusCode(); // Status Code 200-299

            //and the result body should not be null
            var json = await response.Content.ReadAsStringAsync();
            CompanyDto reaultObject = JsonConvert.DeserializeObject<CompanyDto>(json);
            reaultObject.Should().NotBeNull();

            //and the result body should match the company in the database
            reaultObject.Should().BeEquivalentTo(Mapper.Map<CompanyDto>(companyFromDb),
                options => options.IncludingNestedObjects());

        }

        public void Dispose()
        {
            if (addedCompany != null)
                DbContext.Companies.Remove(addedCompany);
        }

    }
}
