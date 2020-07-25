using DataAccessLayer.SAPHandler;
using DataAccessLayer.UnitsOfWorks;
using DataAccessLayer.UnitsOfWorks.SAP;
using FluentAssertions;
using DataAccessLayer.Entities;
using System;
using System.Linq;
using Web_Api.DTOs;
using Xunit;
using System.Collections.Generic;
using System.Diagnostics;
using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Entities.Documents.Items;
using DataAccessLayer.Repositories;

namespace Tests.IntegrationTests.DAL
{
    public class QuotationRepositoryTests : RepositoryTests, IDisposable
    {
        private readonly List<QuotationEntity> _addedQuotationsToCancelAtDispose = new List<QuotationEntity>();

        public QuotationRepositoryTests(DatabaseFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void FindBySnWithInValidSnShouldReturnNull()
        {
            var unitOfWork = DalService.CreateUnitOfWork();
            //Given allocated Quotation repository 
            unitOfWork.Quotations.CountAsync().Result.Should().BeGreaterThan(0);
            //and a invalid SN that match an existing entry
            const short invalidSn = short.MinValue;

            //When call to FIndBySN with the invalid SN 
            var gainQuotation = unitOfWork.Quotations.FindByIdAsync(invalidSn).Result;

            //Then the returned quotation should be null
            gainQuotation.Should().BeNull();

        }

        [Fact]
        public void FindBySnWithValidSnShouldSucceed()
        {
            var unitOfWork = DalService.CreateUnitOfWork();
            //Given allocated Quotation repository 
            unitOfWork.Quotations.CountAsync().Result.Should().BeGreaterThan(0);
            //and a valid SN that match an existing entry
            var validKey = unitOfWork.Quotations.GetAllAsync(PageRequest.Of(0,Int32.MaxValue)).Result
                .ElementAt( new Random().Next(unitOfWork.Quotations.CountAsync().Result)).Key.Value;

            //When call to FIndBySN with the valid SN 
            var gainQuotation = unitOfWork.Quotations.FindByIdAsync(validKey).Result;

            //Then the returned quotation should not be null
            gainQuotation.Should().NotBeNull();
            
            //and contain a SN that match the searched SN
            gainQuotation.Key.Value.Should().Be(validKey);
        }


        [Fact]
        public void AddNewValidQuotationShouldSucceed()
        {
            var numOfQuotationBefore = DalService.CreateUnitOfWork().Quotations.CountAsync().Result;

            //Given a valid new quotation
            var validQuotation = CreateValidQuotation();

            //When adding the new quotation
            var unitOfWork = DalService.CreateUnitOfWork();
            {
                var addedQuotations = unitOfWork.Quotations.AddAsync(validQuotation).Result;
                _addedQuotationsToCancelAtDispose.Add(addedQuotations);

                //Then the result should not be null
                addedQuotations.Should().NotBeNull();
                //and the result's document sum should be close to quantity*pricePerQuantity*(100-discountPrecent)/100 + VAT
                var calculatedTotal = validQuotation.Items.Sum(i => i.PricePerQuantity * i.Quantity * (100 - i.DiscountPercent) / 100);
                Debug.Assert(addedQuotations.VatPercent != null, "addedQuotations.VatPercent != null");
                calculatedTotal += (calculatedTotal * addedQuotations.VatPercent.Value) / 100;
                addedQuotations.DocTotal.Should().BeInRange(calculatedTotal - 1, calculatedTotal + 1);
                //and the transaction should succeed
                unitOfWork.CompleteAsync().Wait();
                //and the repository should contain the new quotation
                Debug.Assert(addedQuotations.Key != null, "addedQuotations.Key != null");
                var quotationAfterCommit = DalService.CreateUnitOfWork().Quotations.FindByIdAsync(addedQuotations.Key.Value).Result;
                quotationAfterCommit.Should().NotBeNull();
                quotationAfterCommit.ValidUntil.Should().Be(validQuotation.ValidUntil);

                var numOfQuotationAfter = DalService.CreateUnitOfWork().Quotations.CountAsync().Result;
                numOfQuotationAfter.Should().Be(numOfQuotationBefore + 1);
            }
               
        }

        [Fact]
        public void AddNewInvalidQuotationShouldFail()
        {
            var numOfQuotationBefore = DalService.CreateUnitOfWork().Quotations.CountAsync().Result;
            //Given an invalid new quotation
            var invalidQuotation = CreateValidQuotation();
            invalidQuotation.Items = new List<DocItemEntity>();//quotation without items is invalid
                                                               //When adding the new quotation
            using (var unitOfWork = DalService.CreateUnitOfWork())
            {

                QuotationEntity addedQuotation = null;
                var transaction = 0;
                Exception exception = null;
                try
                {
                    addedQuotation = unitOfWork.Quotations.AddAsync(invalidQuotation).Result;
                    _addedQuotationsToCancelAtDispose.Add(addedQuotation);
                    transaction = unitOfWork.CompleteAsync().Result;
                }
                catch (Exception e)
                {
                    exception = e;
                }
                finally
                {
                    //Then the result should be null
                    addedQuotation.Should().BeNull();
                    //and the transaction should fail
                    transaction.Should().Be(0);
                    //and throw exception
                    exception.Should().NotBeNull();
                    //and the repository should not affected
                    var numOfQuotationAfter = DalService.CreateUnitOfWork().Quotations.CountAsync().Result;
                    numOfQuotationAfter.Should().Be(numOfQuotationBefore);
                }
            }
        }

        public void Dispose()
        {
            _addedQuotationsToCancelAtDispose.Where(q => q?.Key != null).ToList()
                .ForEach(q =>
                {
                    using (var u = DalService.CreateUnitOfWork())
                    {
                        if (q.Key != null) u.Quotations.CancelAsync(q.Key.Value).Wait();
                        u.CompleteAsync().Wait();
                    }
                });
        }


        private QuotationEntity CreateValidQuotation()
        {
            var quotationCustomer = DalService.CreateUnitOfWork().BusinessPartners
                .FirstOrDefaultAsync(c => c.IsActive == true).Result;

            var quotationOwner = DalService.CreateUnitOfWork().Employees
                .FirstOrDefaultAsync(e => e.IsActive).Result;
            var quotationSalesman = DalService.CreateUnitOfWork().Salesmen
                .FirstOrDefaultAsync(s => s.ActiveStatus == SalesmanEntity.Status.Active).Result;

            return new QuotationEntity
            {
                
                ExternalSn = "testQuotationSN",
                CustomerSn = quotationCustomer.Key,
                CustomerName = quotationCustomer.Name,
                Comments = "this is a test quotation",

                OwnerEmployeeSn = quotationOwner.Sn,
                SalesmanSn = quotationSalesman.Sn,
                Items = new List<DocItemEntity>()
                {
                    new DocItemEntity()
                    {
                        
                        Code = "999999",
                        Description ="testDescription3",
                        PricePerQuantity = 100,
                        Quantity = 1.5M,
                        Details = "testDetails",
                        Comments = "testComments",
                        DiscountPercent = 10,
                        Properties = new Dictionary<string, object>()

                    }
                },

                ValidUntil = DateTime.Now.Date.AddDays(1)
            };
        }
    }
}
