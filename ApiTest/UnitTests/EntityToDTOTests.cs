using FluentAssertions;
using DataAccessLayer.Entities;
using System;
using Web_Api.DTOs;
using Xunit;
using AutoMapper;
using DataAccessLayer.Entities.BusinessPartners;
using Web_Api.DTOs.Mapper;

namespace ApiTest.UnitTests
{
    public class EntityToDTOTests
    {


        private IMapper _mapper;

        private MapperConfiguration _mapperConfiguration;
        public EntityToDTOTests()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityDtoProfile());
            });
            _mapper = _mapperConfiguration.CreateMapper();
        }


        [Fact]
        public void FromSalesmanEntityToDTO()
        {
            //Given a SalesmanEntity

            SalesmanEntity salesmanEntityBeforeConvert = new SalesmanEntity
            {
                Name = "TestName",
                Sn = 1010,
                Mobile = "054-7380602",
                Email = "Test@gmail.com",
                ActiveStatus = SalesmanEntity.Status.NoActive
            };
            //When converting the entity to DTO and than back to an entity
            SalesmanEntity salesmanEntityAfterConvert = _mapper.Map<SalesmanEntity>(_mapper.Map<SalesmanDto>(salesmanEntityBeforeConvert)); 
            salesmanEntityAfterConvert.Should().BeEquivalentTo(salesmanEntityBeforeConvert);
            //and the entity after the convert should not be the  entity before
            salesmanEntityAfterConvert.Should().NotBeSameAs(salesmanEntityBeforeConvert);
        }

        [Fact]
        public void FromAdressEntityToDTO()
        {
            //Given an AdressEntity
            Address address = new Address
            {
                ID = "Addr Biling",
                Country = "Biling country",
                City = "Biling city",
                Block = "Biling block",
                Street = "Biling street",
                NumAtStreet = "Biling numAtSteet",
                Apartment = "Biling Apartment",
                ZipCode = "Biling ZipCode"
            };

            //When converting the entity to DTO and than back to an entity
            Address addressAfterConver = _mapper.Map<Address>(_mapper.Map<AddressDto>(address));
            //Than the entity after the convert should match the entity before
            addressAfterConver.Should().BeEquivalentTo(address, options => options.IncludingNestedObjects());
            //and the entity after the convert should not be the  entity before
            addressAfterConver.Should().NotBeSameAs(address);
        }
        [Fact]
        public void FromCustomerEntityToDTO()
        {
            //Given a FullCustomerEntity
            var businessPartner = new BusinessPartner
            {
                Name = "Lior",
                Key = "205888",
                GroupSn = 100,
                //Group = new CardGroup
                //{
                //    SN = 100,
                //    Name = "TestGroupName"
                //},
                Type = BusinessPartner.CardType.Private,
                FederalTaxId = "515888688",
                Phone1 = "077-6699798",
                Phone2 = "077-5556598",
                Cellular = "057-45465666",
                Email = "Test@gmail.com",
                Fax = "0979855565",
                Balance = 500,
                Comments = "Test Comments",
                IsActive = true,
                SalesmanCode = -1,


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
            };

            //When converting the entity to DTO and than back to an entity
            BusinessPartner businessPartnerAfterConvert = _mapper.Map<BusinessPartner>(_mapper.Map<BusinessPartnerDto>(businessPartner));  
            //Than the entity after the convert should match the entity before
            businessPartnerAfterConvert.Should().BeEquivalentTo(businessPartner, options => options.IncludingNestedObjects());
            //and the entity after the convert should not be the  entity before
            businessPartnerAfterConvert.Should().NotBeSameAs(businessPartner);
        }


        [Fact]
        public void FromEmployeeEntityToDTO()
        {
            //Given a Full EmployeeEntity
            EmployeeEntity employeeEntity = new EmployeeEntity
            {
                Sn = 2,
                IsActive = true,
                FirstName = "TestNameF",
                MiddleName = "TestNameM",
                LastName = "TestNameL",
                ID = "ID200533",
                Gender = EmployeeEntity.GenderTypes.Female,
                Birthday = new DateTime(1992, 6, 16),
                JobTitle = "Job Title",
                Department = new Department
                {
                    Code = 0,
                    Name = "DeptName",
                    Description = "Dept description"
                },
                Position = new JobPosition
                {
                    Code = 0,
                    Name = "PosName",
                    Description = "Position description"
                },
                ManagerSN = 54,
                SalesmanSN = -1,
                HomeAddress = new Address
                {
                    ID = "Addr H",
                    Country = "IL",
                    City = " H city",
                    Block = " H block",
                    Street = " H street",
                    NumAtStreet = " H numAtSteet",
                    Apartment = " H Apartment",
                    ZipCode = " H ZipCode"
                },
                WorkAddress = new Address
                {
                    ID = "Addr W",
                    Country = "IL",
                    City = " W city",
                    Block = " W block",
                    Street = " W street",
                    NumAtStreet = " W numAtSteet",
                    Apartment = " W Apartment",
                    ZipCode = " W ZipCode"
                },
                HomePhone = "054-8998989",
                OfficePhone = "09-89895142",
                WorkCellular = "058-74454151",
                Fax = "8-45642120",
                Email = "l@gmail.com",
                PicPath = "picture URL here",
            };

            //When converting the entity to DTO and than back to an entity
            EmployeeEntity employeeEntityAfterConvert = _mapper.Map<EmployeeEntity>(_mapper.Map<EmployeeDto>(employeeEntity)); 

            //Than the entity after the convert should match the entity before
            employeeEntityAfterConvert.Should().BeEquivalentTo(employeeEntity, options => options.IncludingNestedObjects());
            //and the entity after the convert should not be the  entity before
            employeeEntityAfterConvert.Should().NotBeSameAs(employeeEntity);
        }



        [Fact]
        public void FromAcountBalanceRecordEntityToDTO()
        {
            //Given an AcountBalanceRecordEntity
            AccountBalanceRecordEntity accountBalanceRecordEntity = new AccountBalanceRecordEntity
            {
                OwnerSn = "sfs21515151",
                Doc1Sn = "154569847580",
                Doc2Sn = "212151512",
                Date = DateTime.Now.Date,
                Debt = 500,
                BalanceDebt = 50.55M,
                Memo = "Test Line Memo",
                Type = AccountBalanceRecordEntity.DocumentTypes.CreditInvoice
            };

            //When converting the entity to DTO and than back to an entity
            AccountBalanceRecordEntity accountBalanceRecordEntityAfterConver = _mapper.Map<AccountBalanceRecordEntity>(_mapper.Map<AccountBalanceRecordDto>(accountBalanceRecordEntity));
            //Than the entity after the convert should match the entity before
            accountBalanceRecordEntityAfterConver.Should().BeEquivalentTo(accountBalanceRecordEntity, options => options.IncludingNestedObjects());
            //and the entity after the convert should not be the  entity before
            accountBalanceRecordEntityAfterConver.Should().NotBeSameAs(accountBalanceRecordEntity);
        }



        [Fact]
        public void FromCompanyEntityToDTO()
        {
            //Given an AdressEntity
            CompanyEntity companyEntity = new CompanyEntity
            {
                Name = "CompanyName Test",
                DefaultCurrency = "ILS",
                WebSite = "www.testWebSite.com",
                Phone1 = "05489988-545-566",
                Fax = "126523s23s323s",
                Email = "test@email.com",
                Address = new Address
                {
                    ID = "Addr W",
                    Country = "IL",
                    City = " W city",
                    Block = " W block",
                    Street = " W street",
                    NumAtStreet = " W numAtSteet",
                    Apartment = " W Apartment",
                    ZipCode = " W ZipCode"
                }
            };

            //When converting the entity to DTO and than back to an entity
            CompanyEntity companyEntityAfterConver = _mapper.Map<CompanyEntity>(_mapper.Map<CompanyDto>(companyEntity)); 
            //Than the entity after the convert should match the entity before
            companyEntityAfterConver.Should().BeEquivalentTo(companyEntity, options => options.IncludingNestedObjects());
            //and the entity after the convert should not be the  entity before
            companyEntityAfterConver.Should().NotBeSameAs(companyEntity);
        }
    }
}

