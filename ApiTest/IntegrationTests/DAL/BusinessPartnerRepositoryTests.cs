using FluentAssertions;
using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entities.BusinessPartners;
using DataAccessLayer.Repositories;
using Action = System.Action;

namespace Tests.IntegrationTests.DAL
{
    // [Collection("Sequential")] //run tests sequentially
    public class BusinessPartnerRepositoryTests : RepositoryTests, IDisposable
    {
        private readonly List<string> _customerBeforeTesting;

        public BusinessPartnerRepositoryTests(DatabaseFixture fixture) : base(fixture)
        {
            _customerBeforeTesting = DalService.CreateUnitOfWork().BusinessPartners.GetAllAsync(
                    PageRequest.Of(0, int.MaxValue, Sort<BusinessPartner>.By(x => x.Name)))
                .Result.Select(c => c.Key).ToList();
        }


        [Fact]
        public void AddValidCustomerListShouldSucceed()
        {
            //Given a repository
            var numOfElementsBeforeAdding = DalService.CreateUnitOfWork().BusinessPartners.CountAsync().Result;

            //When add 10 diffident customers
            var customerList = Enumerable.Range(1, 10)
                .Select(i => new BusinessPartner {Name = "TESTAddCustomerListToRepository " + i}).ToList();
            using var uow = DalService.CreateUnitOfWork();
            var customerListAfter = uow.BusinessPartners.AddAsync(customerList).Result.ToList();
            uow.CompleteAsync().Wait();


            //Then 
            //the repository must be 10 elements bigger Customers.GetAllAsync().Result
            var numOfElementsAfterAdding = DalService.CreateUnitOfWork().BusinessPartners.CountAsync().Result;
            numOfElementsAfterAdding.Should().Be(numOfElementsBeforeAdding + 10);
            //and the added list must be of size 10
            customerListAfter.Should().HaveCount(10);
            //and the added list must contain a BusinessPartner id
            customerListAfter.TrueForAll(c => c.Key != null).Should().BeTrue();
            //and the repository must contain the added customers
            var customerAtRepository = DalService.CreateUnitOfWork().BusinessPartners
                .FindAllAsync(c => customerListAfter.Select(c2 => c2.Key).Contains(c.Key),
                    PageRequest.Of(0, 100, Sort<BusinessPartner>.By(x => x.Key))).Result;
            customerAtRepository.Select(c => c.Name).Should().BeEquivalentTo(customerList.Select(c => c.Name));

            //Clear Test
            using var uow2 = DalService.CreateUnitOfWork();
            uow2.BusinessPartners.RemoveAsync(customerListAfter.Select(c => c.Key).ToList()).Wait();
            uow2.CompleteAsync().Wait();
        }


        [Fact]
        public void GetCustomerPagingTest()
        {
            //Given a linq to a database with at least 100 customers
            DalService.CreateUnitOfWork().BusinessPartners.CountAsync().Result.Should().BeGreaterOrEqualTo(100);
            //When activating a paging request
            const int page = 10;
            const int size = 6;
            var customerPagingList = DalService.CreateUnitOfWork()
                .BusinessPartners.GetAllAsync(PageRequest.Of(page, size, Sort<BusinessPartner>.By(x => x.Key))).Result
                .ToList();
            //Then the result will be at the same size
            customerPagingList.Count().Should().Be(size);

            //and the result page must be at the correct position 
            var allCustomers = DalService.CreateUnitOfWork().BusinessPartners
                .GetAllAsync(PageRequest.Of(0, int.MaxValue, Sort<BusinessPartner>.By(x => x.Key))).Result
                .ToList();
            allCustomers.GetRange(page * size, size).ToList()
                .Should().BeEquivalentTo(customerPagingList,
                    options => options.WithoutStrictOrdering().IncludingNestedObjects());
        }

        [Fact]
        public void AddCustomerListWithOneCustomerThatFailWillThrowExceptionAndRollback()
        {
            //Given a BusinessPartner repository
            var numberOfCustomerBefore = DalService.CreateUnitOfWork().BusinessPartners.CountAsync().Result;

            //When Adding a BusinessPartner list with one or more BusinessPartner that have a Cid (not null)
            var customerList = Enumerable.Range(1, 5)
                .Select(i => new BusinessPartner {Name = "TESTAddCustomerListWithOneCustomerThatFailWillRollback " + i})
                .ToList();
            customerList.ElementAt(3).Key = "000";
            customerList.ElementAt(4).Key = "000";
            Action comparison = () =>
            {
                using var uow = DalService.CreateUnitOfWork();
                uow.BusinessPartners.AddAsync(customerList).Wait();
                uow.CompleteAsync().Wait();
            };


            //Then action will throw an exception 
            comparison.Should().Throw<Exception>();

            //and the number of elements in the repository will not affected - transaction will rollback
            var numberOfCustomerAfterTransaction = DalService.CreateUnitOfWork().BusinessPartners.CountAsync().Result;
            numberOfCustomerAfterTransaction.Should().Be(numberOfCustomerBefore);
        }

        [Fact]
        public void AddingCustomerWithCidShouldFailAndThrowException()
        {
            //Given a BusinessPartner repository
            var numberOfCustomerBefore = DalService.CreateUnitOfWork().BusinessPartners.CountAsync().Result;
            //When Adding a BusinessPartner with a Cid (not null)
            var businessPartner = new BusinessPartner
            {
                Key = "000",
                Name = "testName"
            };
            //Than the adding function will throw an exception
            BusinessPartner addedBusinessPartner = null;
            Action comparison = () =>
            {
                using var uow = DalService.CreateUnitOfWork();
                addedBusinessPartner = uow.BusinessPartners.AddAsync(businessPartner).Result;
                uow.CompleteAsync().Wait();
            };
            comparison.Should().Throw<Exception>();

            //and the database will not affected
            DalService.CreateUnitOfWork().BusinessPartners.CountAsync().Result.Should().Be(numberOfCustomerBefore);

            //and the returned BusinessPartner need to be null
            (addedBusinessPartner == null).Should().BeTrue();
        }

        [Fact]
        public async void MultiThreadedAddingCustomersShouldSucceed()
        {
            //Given a BusinessPartner Repository
            var readonlyUow = DalService.CreateUnitOfWork();
            var numberOfCustomerBefore = readonlyUow.BusinessPartners.CountAsync().Result;
            //when a number of different threads want to add some BusinessPartner to the repository at the same time
            const int numOfThreads = 5;
            const int nymOfCustomerPerThread = 5;


            var taskList = Enumerable.Range(1, numOfThreads).ToList().Select(i =>
            {
                return Task<List<BusinessPartner>>.Factory.StartNew(() =>
                {
                    var cc = Enumerable.Range(1, nymOfCustomerPerThread)
                        .Select(j => new BusinessPartner {Name = $"TESTAddCustomerList thread={i}:index={j}"})
                        .ToList();
                    using var u = DalService.CreateUnitOfWork();
                    var customerListAfter = u.BusinessPartners.AddAsync(cc).Result.ToList();
                    u.CompleteAsync().Wait();
                    return customerListAfter;
                });
            }).ToArray();
            var r = (await Task.WhenAll(taskList)).ToList();

            //Then the BusinessPartner Repository will contain all of the BusinessPartner from the different threads
            var numberOfCustomerAfter = readonlyUow.BusinessPartners.CountAsync().Result;
            numberOfCustomerAfter.Should().Be(numberOfCustomerBefore + numOfThreads * nymOfCustomerPerThread);

            r.ForEach(bps =>
            {
                var keys = bps.Select(cf => cf.Key);
                var addedCustomer = readonlyUow.BusinessPartners
                    .FindAllAsync(c => keys.Contains(c.Key),
                        PageRequest.Of(0, nymOfCustomerPerThread + 1)).Result;
                addedCustomer.Select(c => new[] {c.Key, c.Name})
                    .Should().BeEquivalentTo(bps.Select(c => new[] {c.Key, c.Name}),
                        options => options.IncludingNestedObjects());
            });

            //clear test
            var customersToRemove = r.Aggregate((x1, x2) => x1.Union(x2).ToList());
            using var uow = DalService.CreateUnitOfWork();
            uow.BusinessPartners.RemoveAsync(customersToRemove.Select(c => c.Key).ToList()).Wait();
            uow.CompleteAsync().Wait();
        }

        [Fact]
        public void CustomerWithBalanceMustHaveAccountFinanceRecordsToMatchIt()
        {
            //Given a BusinessPartner Repository with BusinessPartner that have a non zero balance
            var customersWithBalance = DalService.CreateUnitOfWork().BusinessPartners
                .FindAllAsync(c => c.Balance != 0,
                    PageRequest.Of(0, 100, Sort<BusinessPartner>.By(x => x.Key))).Result;
            customersWithBalance.Should().HaveCountGreaterThan(0);

            //When query BusinessPartner's account finance 
            var customersAccountRecords = customersWithBalance.Select(c =>
                DalService.CreateUnitOfWork().BusinessPartners
                    .GetAccountBalanceRecordsAsync(c.Key).Result).ToList();


            //Then he must have more then zero records 
            customersAccountRecords.ForEach(rList => rList.Should().HaveCountGreaterThan(0));
            //and the sum of his record must match the total balance
            customersWithBalance.Zip(customersAccountRecords, (c, r) => new {BusinessPartner = c, RecordsList = r})
                .ToList().ForEach(a =>
                    a.RecordsList.Select(r => r.BalanceDebt).Sum().Should().Be(a.BusinessPartner.Balance));
        }


        [Fact]
        public async Task UpdateOneValidBusinessPartnerShouldSucceed()
        {
            //Given a repository
            //with at least 10 diffident customers
            var bp = new BusinessPartner {Name = "TEST_UpdateBpRepository"};
            using var uow = DalService.CreateUnitOfWork();
            bp = await uow.BusinessPartners.AddAsync(bp);
            await uow.CompleteAsync();

            //When update business partner with valid attrs
            using var uow1 = DalService.CreateUnitOfWork();
            (await uow1.BusinessPartners.FindByIdAsync(bp.Key)).Should().NotBeNull();
            bp.Phone2 = "053-555555";
            await uow1.BusinessPartners.UpdateAsync(bp);
            await uow1.CompleteAsync();


            //Then 
            using var uow2 = DalService.CreateUnitOfWork();
            var result = await uow2.BusinessPartners.FindByIdAsync(bp.Key);
            result.Key.Should().Be(bp.Key);
            result.Should().BeEquivalentTo(bp, opt => opt
                .Excluding(x => x.LastUpdateDateTime)
                .Excluding(x=>x.CreationDateTime)//TODO
                .IncludingNestedObjects()
            );

            //Clear Test
            using var uow3 = DalService.CreateUnitOfWork();
            uow3.BusinessPartners.RemoveAsync(bp.Key).Wait();
            await uow3.CompleteAsync();
        }


        public void Dispose()
        {
            //clear added BusinessPartner if any test failed
            using var uow = DalService.CreateUnitOfWork();
            uow.BusinessPartners.RemoveAsync(
                uow.BusinessPartners.GetAllAsync(
                        PageRequest.Of(0, int.MaxValue, Sort<BusinessPartner>.By(x => x.Name))).Result
                    .Select(c => c.Key)
                    .Except(_customerBeforeTesting).ToList()).Wait();
            uow.CompleteAsync().Wait();
        }
    }
}