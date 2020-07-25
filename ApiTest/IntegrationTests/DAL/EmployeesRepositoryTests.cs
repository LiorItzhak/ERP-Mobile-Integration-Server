using DataAccessLayer.SAPHandler;
using DataAccessLayer.UnitsOfWorks;
using DataAccessLayer.UnitsOfWorks.SAP;
using FluentAssertions;
using DataAccessLayer.Entities;
using System;
using Web_Api.DTOs;
using Xunit;
using System.Linq;
using DataAccessLayer.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Web_Api;

namespace Tests.IntegrationTests.DAL
{
    public class EmployeesRepositoryTests : RepositoryTests
    {
        public EmployeesRepositoryTests(DatabaseFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void GetAllEmployeesShouldSucceed()
        {

            var unitOfWork = DalService.CreateUnitOfWork();
            //Given allocated employee's repository
            unitOfWork.Employees.CountAsync().Result.Should().BeGreaterThan(0);

            //When GetAll Employees
            var allEmployees = unitOfWork.Employees.GetAllAsync(PageRequest.Of(0,int.MaxValue)).Result.ToList();

            //Then the number of gain employees should match the number of  allocated employees
            allEmployees.Count().Should().Be(unitOfWork.Employees.CountAsync().Result);

            //and each employee should have an unique SN
            allEmployees.Select(e => e.Sn).Distinct().Count().Should().Be(allEmployees.Count());
        }

        [Fact]
        public void FindByIdEmployeesShouldSucceed()
        {

            var unitOfWork = DalService.CreateUnitOfWork();
            //Given allocated employee's repository 
            unitOfWork.Employees.CountAsync().Result.Should().BeGreaterThan(0);

            var allEmployees = unitOfWork.Employees.GetAllAsync(PageRequest.Of(0,int.MaxValue)).Result.ToList();
            var validSn = unitOfWork.Employees.GetAllAsync(PageRequest.Of(0,int.MaxValue)).Result
            .ElementAt(new Random().Next(allEmployees.Count() - 1)).Sn;
            //When call to FindByID  with a valid SN
            var employee = unitOfWork.Employees.FindByIdAsync(validSn).Result;

            //Then the employee should not be null
            employee.Should().NotBeNull();

            //and have the searched SN
            employee.Sn.Should().Be(validSn);
        }
    }


}
