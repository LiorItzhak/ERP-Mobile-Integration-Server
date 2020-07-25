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

namespace Tests.IntegrationTests.DAL
{
    public class CompanyRepositoryTests : RepositoryTests
    {
        public CompanyRepositoryTests(DatabaseFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void GetCompanyShouldSucceed()
        {
            //Given allocated company repository

            //When call to Get Company 
            var company = DalService.CreateUnitOfWork().Company.GetAsync().Result;

            //Then the company should not be null
            company.Should().NotBeNull();
            //and the company should contain a name
            company.Name.Should().NotBeNullOrWhiteSpace();
        }
    }
}
