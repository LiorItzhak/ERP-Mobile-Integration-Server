using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.BusinessPartners;
using DataAccessLayer.Repositories;
using FluentAssertions;
using Newtonsoft.Json;
using Web_Api.DTOs;
using Xunit;

namespace Tests.IntegrationTests.WebApi
{
    [Collection("Sequential")] //run tests sequentially
    public class BusinessPartnersWebControllerTests : WebControllerTests ,IDisposable
    {
        [Theory]
        [InlineData("/api/BusinessPartner?page=0&size=3")]
        [InlineData("/api/BusinessPartner?page=1&size=3")]
        [InlineData("/api/BusinessPartner?page=2&size=2")]
        [InlineData("/api/BusinessPartner?page=0&size=300")]
        public async Task GetBusinessPartnersPaging(string url)
        {
            //Given a running server with businessPartners allocated in his database
            DalService.CreateUnitOfWork().BusinessPartners.GetAllAsync(PageRequest.Of(0,1)).Result.Should().HaveCountGreaterThan(0);

            //When a client ask for URL /api/BusinessPartner&page=x&size=y
            var client = TestServer.CreateClient();
            var response = await client.GetAsync(url);

            //Then the response will be successful
            response.EnsureSuccessStatusCode(); // Status Code 200-299

            //and the result body should not be null
            var json = await response.Content.ReadAsStringAsync();
            var resultObjects = JsonConvert.DeserializeObject<IEnumerable<BusinessPartnerDto>>(json);
            var businessPartnersDto = resultObjects as BusinessPartnerDto[] ?? resultObjects.ToArray();
            businessPartnersDto.Should().NotBeNull();

            //and the result body should contain size or less elements
            var size = Convert.ToInt32(url.Split("size=")[1]);
            //var page = Convert.ToInt32(url.Split("page=")[1].Split("&")[0]);
            businessPartnersDto.Should().HaveCountLessOrEqualTo(size);
            var bpsKeys = businessPartnersDto.Select(x => x.Key);
            //and the result body should match the businessPartners in the database
            var allBusinessPartnersFromDb = DalService.CreateUnitOfWork()
                .BusinessPartners.FindAllAsync(x=>bpsKeys.Contains(x.Key),PageRequest.Of(0,int.MaxValue)).Result
                .Select(e => Mapper.Map<BusinessPartnerDto>(e)).ToList();
            allBusinessPartnersFromDb.Count.Should().BeLessOrEqualTo(size);
            businessPartnersDto.Should().BeEquivalentTo(allBusinessPartnersFromDb, options => options.IncludingNestedObjects());

        }


        [Theory]
        [InlineData("/api/BusinessPartner/{key}")]
        public async Task GetBusinessPartnerById(string baseUrl)
        {
            //Given a running server with businessPartners allocated in his database 
            var bpsInDb = DbContext.BusinessPartners.ToList();
            foreach (var bpFromDb in bpsInDb)
            {
                //When a client ask for URL /api/BusinessPartner/GetByID/5
                var client = TestServer.CreateClient();
                var url = baseUrl.Replace("{key}", bpFromDb.Key);
                var response = await client.GetAsync(url);

                //Then the response will be successful
                response.EnsureSuccessStatusCode(); // Status Code 200-299

                //and the result body should not be null
                var json = await response.Content.ReadAsStringAsync();
                var resultObject = JsonConvert.DeserializeObject<BusinessPartnerDto>(json);
                resultObject.Should().NotBeNull();
                resultObject.Key.Should().Be(bpFromDb.Key);
                //and the result body should match the businessPartners in the database
                resultObject.Should().BeEquivalentTo(Mapper.Map<BusinessPartnerDto>(bpFromDb),options => options.IncludingNestedObjects());
            }
        }


        [Theory]
        [InlineData("/api/BusinessPartner/")]
        public async Task PostBusinessPartner(string url)
        {

            //Given a running server with CardGroup and Salesman
            DbContext.Salesmen.Add(new SalesmanEntity
            {
                Sn = -1,
                Name = "TEST_S",
                ActiveStatus = SalesmanEntity.Status.Active
            });
            DbContext.CardGroups.Add(new CardGroup { Sn = 100, Name = "TEST_S" });
            DbContext.SaveChanges();

            var validGroupCodes = DalService.CreateUnitOfWork().BusinessPartners.GetAllGroupsAsync().Result;
            var validSalesmen = DalService.CreateUnitOfWork().Salesmen.GetAllAsync(PageRequest.Of(0,int.MaxValue)).Result;

            var businessPartnersToPost = Enumerable.Range(1, 3).ToList()
                .Select(i => new BusinessPartner {
                    Name = "TestWebBusinessPartner" + i,
                    GroupSn = validGroupCodes.FirstOrDefault()?.Sn,
                    SalesmanCode = validSalesmen.FirstOrDefault()?.Sn,
                    PartnerType =  BusinessPartner.PartnerTypes.Customer,
                    Type = BusinessPartner.CardType.Private
                }).ToList();

            foreach (var businessPartnerToPost in businessPartnersToPost)
            {
                var jsonSend = JsonConvert.SerializeObject(Mapper.Map<BusinessPartnerDto>(businessPartnerToPost));
                //When a client ask for URL /api/BusinessPartner} with a valid BusinessPartner in the request body
                var client = TestServer.CreateClient();
                var response = await client.PostAsync(url,new StringContent(jsonSend,Encoding.UTF8, "application/json"));


                //Then the response will be successful
                response.EnsureSuccessStatusCode(); // Status Code 200-299

                //and the result body should be null and the name need to match
                var json = await response.Content.ReadAsStringAsync();
                var resultObject = JsonConvert.DeserializeObject<BusinessPartnerDto>(json);
                resultObject.Should().NotBeNull();
                resultObject.Name.Should().Be(businessPartnerToPost.Name);
                resultObject.Should().BeEquivalentTo(businessPartnerToPost,opt=>opt
                    .Excluding(x=>x.CreationDateTime)
                    .Excluding(x=>x.LastUpdateDateTime)
                    .Excluding(x=>x.Key)
                    .IncludingNestedObjects()
                );

                //and the businessPartners should be added to the database
                DalService.CreateUnitOfWork().BusinessPartners.FindByIdAsync(resultObject.Key).Result
                    .Should().NotBeNull();
                
            }
        }


        [Theory]
        [InlineData("/api/BusinessPartner")]
        public async Task UpdateBusinessPartner(string url)
        {
            //Given a running server with businessPartners allocated in his database 
            using var unitOfWork = DalService.CreateUnitOfWork();
            var bpsInDb = DbContext.BusinessPartners.Take(3).ToList();
            await unitOfWork.CompleteAsync();
            foreach (var businessPartnerFromDb in bpsInDb)
            {
                //When a client update the name of a valid BusinessPartner and ask for URL /api/BusinessPartner with the updated BusinessPartner
                var updateName = businessPartnerFromDb.Name+ " UPDATENAME";
                businessPartnerFromDb.Name = updateName;
                var bpDtoToSend = Mapper.Map<BusinessPartnerDto>(businessPartnerFromDb);
                var jsonSend = JsonConvert.SerializeObject(bpDtoToSend);
                var client = TestServer.CreateClient();
                var response = await client.PutAsync($"{url}/{businessPartnerFromDb.Key}", new StringContent(jsonSend, Encoding.UTF8, "application/json"));

                //Then the response will be successful
                response.EnsureSuccessStatusCode(); // Status Code 200-299

                //and the result body should be null 
                var json = await response.Content.ReadAsStringAsync();
                var resultBpDto = JsonConvert.DeserializeObject<BusinessPartnerDto>(json);
                resultBpDto.Should().NotBeNull();
                
                //and the result should contain the updated name

                resultBpDto.Name.Should().Be(updateName);
                resultBpDto.Should().BeEquivalentTo(bpDtoToSend,config=> config.Excluding(x=>x.LastUpdateDateTime));
                var resultBp = Mapper.Map<BusinessPartner>(resultBpDto);
                
                Debug.Assert(businessPartnerFromDb.CreationDateTime != null, "businessPartnerFromDb.CreationDateTime != null");
                resultBp.LastUpdateDateTime.Should()
                    .BeAfter(businessPartnerFromDb.LastUpdateDateTime ?? businessPartnerFromDb.CreationDateTime.Value);
                    
                    
                //and the BusinessPartner should be updated in database
                var updatedBusinessPartner = DalService.CreateUnitOfWork().BusinessPartners
                  .FindAllAsync(c => c.Key == resultBpDto.Key,
                      PageRequest.Of(0,10,Sort<BusinessPartner>.By(x=>x.Key))).Result.ElementAt(0);
                updatedBusinessPartner.Name.Should().Be(updateName);
            }
        }


        public void Dispose()
        {

        }
    }
}
