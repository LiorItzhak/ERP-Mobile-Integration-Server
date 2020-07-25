using DataAccessLayer.Entities;
using FluentAssertions;
using FluentValidation;
using LogicLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DataAccessLayer.Entities.BusinessPartners;
using Xunit;

namespace Tests.ServicesTests
{
    public class CustomerServiceTests : BaseServicesTest
    {
        private readonly IBusinessPartnerService _customerService;

        public CustomerServiceTests()
        {
            //allocateDB 
            DbContext.Salesmen.Add(new SalesmanEntity()
            {
                Sn = -1,
                Name = "TEST_S",
                ActiveStatus = SalesmanEntity.Status.Active
            });
            DbContext.CardGroups.Add(new CardGroup() { Sn = 100, Name = "TEST_S" });
            DbContext.SaveChanges();
            AllocateDemoCustomers();

            _customerService = GetServiceProvider<IBusinessPartnerService>();
        }


        [Fact]
        public void AddCustomerWithCidShouldThrowValidateException()
        {
            //Given a BusinessPartner with a Cid
            var customerToAdd = new BusinessPartner() { Key = "TestCid" };
            //When trying  to add the BusinessPartner
            var aggregateException = _customerService.AddBusinessPartnerAsync(customerToAdd, CancellationToken.None).Exception;
            //Then the operation should throw a ValidationException
            aggregateException.Should().NotBeNull();
            var error = aggregateException.InnerException;
            error.Should().BeOfType(typeof(ValidationException));

        }

        [Fact]
        public void AddCustomerWithoutNameShouldThrowValidateException()
        {
            //Given a BusinessPartner with empty or 
            var customerToAdd = new BusinessPartner() { Name = null };
            var customerToAdd2 = new BusinessPartner() { Name = "  " };

            //When try to add the BusinessPartner
            var aggregateException = _customerService.AddBusinessPartnerAsync(customerToAdd, CancellationToken.None).Exception;
            var aggregateException2 = _customerService.AddBusinessPartnerAsync(customerToAdd2, CancellationToken.None).Exception;

            //Then the operation should throw a ValidationException
            aggregateException.Should().NotBeNull();
            aggregateException2.Should().NotBeNull();

            var error = aggregateException.InnerException;
            error.Should().BeOfType(typeof(ValidationException));
            error = aggregateException2.InnerException;
            error.Should().BeOfType(typeof(ValidationException));

        }




        private void AllocateDemoCustomers(string name = "TestCustomer", int count = 5)
        {


            DbContext.BusinessPartners.AddRange(
            Enumerable.Range(1, count).ToList()
             .Select(i => new BusinessPartner
             {
                 Name = name + ":" + i,
                 CreationDateTime = DateTime.Now.AddDays(-i),
                 GroupSn = DbContext.CardGroups.First().Sn,
                 SalesmanCode = DbContext.Salesmen.First()?.Sn,

                 Type = BusinessPartner.CardType.Private,
                 FederalTaxId = "515888688",
                 Phone1 = "077-6699798",
                 Phone2 = "077-5556598",
                 Cellular = "057-45465666",
                 Email = "Test@gmail.com",
                 Fax = "0979855565",
                 Balance = 500,
                 Comments = "Test Comments",
                 IsActive =true,


                 BillingAddress = new Address
                 {
                     ID = "Addr Biling",
                     Country = "Biling country",
                     City = "Biling city",
                     Block = "Biling block",
                     Street = "Biling street",
                     NumAtStreet = "Biling numAtSteet",
                     Apartment = "Biling Apartment",
                     ZipCode = "Biling ZipCode"
                 },
                 ShippingAddress = new Address
                 {
                     ID = "Addr Shipping",
                     Country = "Shipping country",
                     City = "Shipping city",
                     Block = "Shipping block",
                     Street = "Shipping street",
                     NumAtStreet = "Shipping numAtSteet",
                     Apartment = "Shipping Apartment",
                     ZipCode = "Shipping ZipCode"
                 },

             }));

            DbContext.SaveChanges();
        }


    }
}
