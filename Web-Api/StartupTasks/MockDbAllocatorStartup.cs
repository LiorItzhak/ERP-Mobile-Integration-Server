using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using Bogus.DataSets;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Impls.Ral;
using Bogus.Extensions.UnitedStates;
using DataAccessLayer.Entities.BusinessPartners;
using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Entities.Documents.Headers;
using DataAccessLayer.Entities.Documents.Items;
using DataAccessLayer.Entities.Products;
using DataAccessLayer.Entities.Products.Properties;
using Geocoding;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Address = DataAccessLayer.Entities.Address;
using Database = Bogus.Database;
using IdentityUser = DataAccessLayer.Entities.Authentication.IdentityUser;


namespace Web_Api.StartupTasks
{
    public class MockDbAllocatorStartup : IStartupTask
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RalDbContext _dbContext;
        private readonly ILogger<MockDbAllocatorStartup> _logger;

        public MockDbAllocatorStartup(RalDbContext dbContext, UserManager<IdentityUser> userManager,
            ILogger<MockDbAllocatorStartup> logger)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken = default)
        {
    

            //https://github.com/bchavez/Bogus
            //Set the randomizer seed if you wish to generate repeatable data sets.
            Randomizer.Seed = new Random(0);
            await FakeCompany();
            var activitySubjects = await FakeActivitySubjects(5);
            var activityTypes  = await FakeActivityTypes(4);
            
            var salesmen = await FakeSalesmen(4);
            var employees = await FakeEmployees(salesmen, 10);
            await FakeLastLocation(employees);
            await FakeUsers(employees);
            var cardGroups = await FakeCardGroups(5);
            var businessPartners = await FakeBusinessPartners(salesmen, cardGroups, 50);
            var customers = businessPartners.Where(x => x.PartnerType == BusinessPartner.PartnerTypes.Customer)
                .ToArray();
            var products = await FakeProducts(20);
            await FakeDocument<InvoiceEntity>(customers, salesmen, employees, products, 200);
            await FakeDocument<OrderEntity>(customers, salesmen, employees, products, 300);
            await FakeDocument<CreditNoteEntity>(customers, salesmen, employees, products, 10);
            await FakeDocument<QuotationEntity>(customers, salesmen, employees, products, 50);
            await FakeDocument<DeliveryNoteEntity>(customers, salesmen, employees, products, 10);
            // await FakeDocument<DownPaymentRequest>(customers, salesmen, employees, products, 5);
            await FakeBalances(customers);
           // await FakeActivities(10, activitySubjects, activityTypes, businessPartners, employees);
        }


        private async Task<ActivityType[]> FakeActivityTypes(int count)
        {
            var faker = new Faker<ActivityType>()
                .RuleFor(x => x.Name, f => f.Lorem.Word())
                .RuleFor(x => x.IsActive, f => f.Random.Bool());
            _dbContext.ActivityTypes.AddRange(faker.Generate(count));
            await _dbContext.SaveChangesAsync();
            return await _dbContext.ActivityTypes.ToArrayAsync();
        }

        private async Task<ActivitySubject[]> FakeActivitySubjects(int count)
        {
            var faker = new Faker<ActivitySubject>()
                .RuleFor(x => x.Name, f => f.Lorem.Word())
                .RuleFor(x => x.IsActive, f => f.Random.Bool());
            _dbContext.ActivitySubjects.AddRange(faker.Generate(count));
            await _dbContext.SaveChangesAsync();
            return await _dbContext.ActivitySubjects.ToArrayAsync();
        }
        private async Task<Activity[]> FakeActivities(int count,ActivitySubject[] activitySubjects,ActivityType[] activityTypes,BusinessPartner[] businessPartners,EmployeeEntity[] employees)
        {
            var faker = new Faker<Activity>()
                .RuleFor(x => x.BusinessPartnerCode, f => f.PickRandom(businessPartners.Select(x=>x.Key)))
                .RuleFor(x => x.HandleByEmployeeCode, f => f.PickRandom(employees.Select(x=>x.Sn)))
                .RuleFor(x=>x.Action , f=>f.PickRandom<Activity.ActionType>())
                .RuleFor(x => x.TypeCode, f => f.PickRandom(activityTypes.Select(x=>x.Code)))
                .RuleFor(x => x.SubjectCode, f => f.PickRandom(activitySubjects.Select(x=>x.Code)))
                .RuleFor(x => x.Details, f => f.Lorem.Sentence())
                .RuleFor(x => x.Notes, f => f.Lorem.Sentences())
                .RuleFor(x => x.BeginDateTime, f => f.Date.BetweenOffset(DateTimeOffset.Now.AddDays(-90), DateTimeOffset.Now.AddDays(90)))
                .RuleFor(x => x.DurationMinutes, f => f.Random.Int(1,60))
                .RuleFor(x => x.CreationDateTime, (f,x) => f.Date.Between(DateTime.Now.AddDays(-90),x.BeginDateTime))
                // .RuleFor(x => x.LastModifiedDateTime, (f,x) =>
                // {
                //     if (x.CreationDateTime != null) return f.Date.Between(x.CreationDateTime.Value, DateTime.Now);
                //     return null;
                // })

                .RuleFor(x => x.IsActive, f => f.Random.Bool());
            _dbContext.Activities.AddRange(faker.Generate(count));
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Activities.ToArrayAsync();
        }

        private async Task FakeCompany()
        {
            var fakeCompany = new Faker<CompanyEntity>()
                .RuleFor(x => x.Name, "Fake Company")
                .RuleFor(x => x.VatPercent, f => f.Random.Decimal(0.0M, 0.5M))
                .RuleFor(x => x.DefaultCurrency, "ILS");
            _dbContext.Companies.AddRange(fakeCompany.Generate());
            await _dbContext.SaveChangesAsync();
        }

        private async Task<EmployeeEntity[]> FakeEmployees(IEnumerable<SalesmanEntity> salesmen, int count)
        {
            var salesmenSns = salesmen.Select(x => x.Sn).ToList();
            var faker = new Faker<EmployeeEntity>()
                    .RuleFor(x => x.ID, f => f.Person.Ssn())
                    .RuleFor(x => x.Email, f => f.Person.Email)
                    .RuleFor(x => x.Gender, f => f.PickRandom<EmployeeEntity.GenderTypes>())
                    .RuleFor(x => x.PicPath,
                        (f, x) => f.Image.LoremFlickrUrl(keywords: f.PickRandom("man", "woman", "face", "person")))
                    .RuleFor(x => x.FirstName, f => f.Person.FirstName)
                    .RuleFor(x => x.LastName, f => f.Person.LastName)
                    .RuleFor(x => x.IsActive, f => true)
                    .RuleFor(x => x.SalesmanSN, f =>
                    {
                        if (salesmenSns.Count == 0) return null;
                        var sn = salesmenSns[0];
                        salesmenSns.RemoveAt(0);
                        return sn;
                    })
                    .RuleFor(x => x.HomeAddress, f => AddressFaker.Generate())
                    .RuleFor(x => x.WorkAddress, f => AddressFaker.Generate())
                    .RuleFor(x => x.HomePhone, f => f.Person.Phone)
                    .RuleFor(x => x.JobTitle, f => f.Lorem.Word())
                ;

            _dbContext.Employees.AddRange(faker.Generate(count));
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Employees.ToArrayAsync();
        }

        private async Task<IdentityUser[]> FakeUsers(IEnumerable<EmployeeEntity> employees, string password = "1234")
        {
            foreach (var employee in employees)
            {
                var user = new IdentityUser
                {
                    Email = employee.Email,
                    EmpId = employee.Sn,
                    UserName = employee.Sn.ToString()
                };
                await _userManager.CreateAsync(user, password);
            }

            return await _dbContext.IdentityUsers.ToArrayAsync();
        }

        private async Task<CardGroup[]> FakeCardGroups(int count)
        {
            var faker = new Faker<CardGroup>()
                .RuleFor(x => x.Name, f => f.Address.State());
            _dbContext.CardGroups.AddRange(faker.Generate(count));
            await _dbContext.SaveChangesAsync();
            return await _dbContext.CardGroups.ToArrayAsync();
        }

        
        private async Task<BusinessPartner[]> FakeBusinessPartners(IEnumerable<SalesmanEntity> salesmen,
            IEnumerable<CardGroup> cardGroups,
            int count)
        {
            var faker = new Faker<BusinessPartner>()
                    .RuleFor(c => c.PartnerType, f => f.PickRandom<BusinessPartner.PartnerTypes>())
                    .RuleFor(c => c.Type, f => f.PickRandom<BusinessPartner.CardType>())
                    .RuleFor(c => c.CreationDateTime, f => f.Date.Past(6, DateTime.Now))
                    .RuleFor(c => c.LastUpdateDateTime,
                        (f, c) => new Random().Next(10) < 4
                            ? f.Date.Between(c.CreationDateTime.Value, DateTime.Now)
                            : new DateTime?())
                    .RuleFor(c => c.Name, (f, c) => f.Company.CompanyName())
                    .RuleFor(c => c.FederalTaxId, (f, c) => f.Company.Ein())
                    .RuleFor(i => i.Currency, f => "$")
                    .RuleFor(c => c.Email, (f, c) => new Random().Next(10) < 6 ? f.Internet.Email(c.Name) : null)
                    .RuleFor(c => c.Phone1, (f, c) => f.Phone.PhoneNumber("0#-#######"))
                    .RuleFor(c => c.Phone2,
                        (f, c) => new Random().Next(10) < 4 ? f.Phone.PhoneNumber("05#-#######") : null)
                    .RuleFor(c => c.Cellular, (f, c) => f.Phone.PhoneNumber("05#-#######"))
                    .RuleFor(c => c.Fax, (f, c) => new Random().Next(10) < 4 ? f.Phone.PhoneNumber("0#-#######") : null)
                    .RuleFor(c => c.IsActive, f => true /*f.Random.Bool()*/)
                    .RuleFor(c => c.GroupSn, (f, c) => f.PickRandom(cardGroups).Sn)
                    .RuleFor(c => c.SalesmanCode, (f, c) => f.PickRandom(salesmen).Sn)
                    .RuleFor(c => c.ShippingAddress, (f, c) => AddressFaker.Generate())
                    .RuleFor(c => c.BillingAddress, (f, c) => AddressFaker.Generate())
                    .RuleFor(c => c.OrdersBalance, 0)
                    .RuleFor(c => c.DeliveryNotesBalance, 0)
                    .RuleFor(c => c.IsVatFree, f => f.Random.Bool())
                    .RuleFor(c => c.DiscountPercent, f => f.Random.Decimal())
                    .RuleFor(c => c.GeoLocation, (f, c) => new GeoLocation
                    {
                        Address = $"{c.BillingAddress.City},{c.BillingAddress.Street} {c.BillingAddress.NumAtStreet}",
                        Latitude = 15.00,
                        Longitude = 15.5656
                    })
                    .RuleFor(c => c.Balance, f => f.Random.Decimal())
                    .RuleFor(c => c.OrdersBalance, f => f.Random.Decimal())
                    .RuleFor(c => c.DeliveryNotesBalance, f => f.Random.Decimal())
                ;

            _dbContext.BusinessPartners.AddRange(faker.Generate(count));
            await _dbContext.SaveChangesAsync();
            return await _dbContext.BusinessPartners.ToArrayAsync();
        }

        private async Task<SalesmanEntity[]> FakeSalesmen(int count)
        {
            var faker = new Faker<SalesmanEntity>()
                .RuleFor(x => x.Name, f => f.Person.FullName)
                .RuleFor(x => x.Email, f => f.Person.Email)
                .RuleFor(x => x.Mobile, f => f.Person.Phone)
                .RuleFor(x => x.ActiveStatus, f => SalesmanEntity.Status.Active);
            _dbContext.Salesmen.AddRange(faker.Generate(count));
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Salesmen.ToArrayAsync();
        }

        private async Task<ProductEntity[]> FakeProducts(int count)
        {
            var faker = new Faker<ProductGroupEntity>()
                .RuleFor(x => x.Name, f => f.Commerce.Categories(1)[0])
                .RuleFor(x => x.PictureUrl, (f, x) => f.Image.LoremFlickrUrl(keywords: x.Name))
                .RuleFor(x => x.CreationDateTime, f => f.Date.Past(3, DateTime.Now))
                .RuleFor(x => x.LastUpdateDateTime,
                    (f, x) => f.Random.Float() < 0.8
                        ? f.Date.Between(x.CreationDateTime.Value, DateTime.Now)
                        : new DateTime?());

            _dbContext.ProductGroups.AddRange(faker.Generate(8));
            await _dbContext.SaveChangesAsync();
            var productsGroups = await _dbContext.ProductGroups.ToListAsync();
            productsGroups.ForEach(p =>
            {
                var productFaker = new Faker<ProductEntity>()
                    .RuleFor(x => x.GroupCode, p.Code)
                    .RuleFor(x => x.Name, (f, x) => p.Name + " " + f.Lorem.Word())
                    .RuleFor(x => x.Barcode, (f, x) => f.Commerce.Ean13())
                    .RuleFor(x => x.PictureUrl,
                        (f, x) => f.Image.LoremFlickrUrl(
                            keywords: productsGroups.First(g => g.Code == x.GroupCode).Name))
                    .RuleFor(x => x.IsActive, f => f.Random.Float() < 0.9)
                    .RuleFor(x => x.IsActive, f => f.Random.Float() < 0.9)
                    .RuleFor(x => x.IsForSell, f => f.Random.Float() < 0.9)
                    .RuleFor(x => x.IsForBuy, f => f.Random.Float() < 0.2)
                    .RuleFor(x => x.CreationDateTime, f => f.Date.Past(3, DateTime.Now))
                    .RuleFor(x => x.LastUpdateDateTime,
                        (f, x) => f.Random.Float() < 0.8
                            ? f.Date.Between(x.CreationDateTime.Value, DateTime.Now)
                            : new DateTime?())
                    .RuleFor(x => x.AutoQuantityCalculationExpression, "units*length*height*width")
                    .RuleFor(x => x.Properties, new List<ProductPropertyEntity>
                    {
                        new ProductPropertyEntity
                        {
                            Code = "height", Type = ProductPropertyEntity.PropertyType.Decimal, MinValue = 0, UOM = "M",
                            DefaultValue = 1
                        },
                        new ProductPropertyEntity
                        {
                            Code = "width", Type = ProductPropertyEntity.PropertyType.Decimal, MinValue = 0, UOM = "M",
                            DefaultValue = 1
                        },
                        new ProductPropertyEntity
                        {
                            Code = "length", Type = ProductPropertyEntity.PropertyType.Decimal, MinValue = 0, UOM = "M",
                            DefaultValue = 1
                        },
                        new ProductPropertyEntity
                        {
                            Code = "units", Type = ProductPropertyEntity.PropertyType.Int, MinValue = 0,
                            DefaultValue = 1
                        },
                    });

                _dbContext.Products.AddRange(productFaker.Generate(count));
            });
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Products.ToArrayAsync();
        }


        private readonly Faker<Address> AddressFaker = new Faker<Address>()
            .RuleFor(a => a.ID, f => f.UniqueIndex.ToString())
            .RuleFor(a => a.Country, f => "IL")
            .RuleFor(a => a.City, f => f.Address.City())
            .RuleFor(a => a.Street, f => f.Address.StreetName())
            .RuleFor(a => a.NumAtStreet, f => f.Address.BuildingNumber())
            .RuleFor(a => a.Apartment, f => new Random().Next(10) < 7 ? f.Random.Int(0, 100) + "" : null)
            .RuleFor(a => a.ZipCode, f => new Random().Next(10) < 4 ? f.Address.ZipCode() : null);


        private Faker<DocItemEntity> DocItemFaker(IEnumerable<ProductEntity> products)
        {
            return new Faker<DocItemEntity>()
                .RuleFor(i => i.Code, f => f.PickRandom(products).Code)
                .RuleFor(i => i.Description, (f, x) => products.First(i => i.Code == x.Code).Name)
                .RuleFor(i => i.Currency, "$")
                .RuleFor(i => i.PricePerQuantity, (f, i) => Math.Round(f.Random.Decimal() * 10m + 0.1m, 2))
                .RuleFor(i => i.DiscountPercent, f => Math.Round(f.Random.Decimal(0, 0.5m) * 100m, 2))
                .RuleFor(i => i.Comments, f => f.Lorem.Sentence())
                .RuleFor(i => i.Details, f => f.Lorem.Sentence(5))
                .RuleFor(i => i.Comments, f => f.Lorem.Sentence(10))
                .RuleFor(i => i.Properties, f => new Dictionary<string, object>()
                {
                    {"width", Math.Round(f.Random.Decimal(0m, 7m), 3)},
                    {"height", Math.Round(f.Random.Decimal(0m, 7m), 3)},
                    {"length", Math.Round(f.Random.Decimal(0m, 7m), 3)},
                    {"units", f.Random.UInt(1, 10)},
                })
                .RuleFor(i => i.Quantity, (f, itm) =>
                {
                    decimal q = 1m;
                    if (itm.Properties.ContainsKey("width"))
                        q *= (decimal) itm.Properties["width"];
                    if (itm.Properties.ContainsKey("height"))
                        q *= (decimal) itm.Properties["height"];
                    if (itm.Properties.ContainsKey("length"))
                        q *= (decimal) itm.Properties["length"];
                    if (itm.Properties.ContainsKey("units"))
                        q *= (UInt32) itm.Properties["units"];
                    if (q == 1)
                        q = f.Random.Decimal(1, 30);
                    return Math.Round(q, 3);
                });
        }


        private async Task FakeDocument<TDocument>(
            IEnumerable<BusinessPartner> customers,
            IEnumerable<SalesmanEntity> salesmen,
            IEnumerable<EmployeeEntity> employees,
            IEnumerable<ProductEntity> products,
            int count = 10)
            where TDocument : DocumentHeaderEntity, IDocumentEntity
        {
            var docItemFaker = DocItemFaker(products);
            var faker = new Faker<TDocument>()
                .RuleFor(i => i.Sn, f => f.UniqueIndex)
                .RuleFor(i => i.Comments, f => f.Lorem.Paragraph(1))
                .RuleFor(i => i.IsCanceled, f => f.Random.Float() < 0.2)
                .RuleFor(i => i.IsClosed, (f, i) => i.IsCanceled)
                .RuleFor(i => i.SalesmanSn, (f, i) => f.PickRandom(salesmen).Sn)
                .RuleFor(i => i.OwnerEmployeeSn, (f, i) => f.PickRandom(employees).Sn)
                .RuleFor(i => i.Currency, f => "$")
                .RuleFor(i => i.Items, (f, x) =>
                    Enumerable.Range(1, f.Random.Number(1, 12)).Select(n =>
                    {
                        var itm = docItemFaker.Generate();
                        itm.ItemNumber = n;
                        return itm;
                    }).ToList())
                .RuleFor(i => i.DocTotal, (f, x) => Math.Round(x.Items.Sum(i => i.Price), 2))
                .RuleFor(i => i.ToPay, (f, x) => x.DocTotal)
                .RuleFor(i => i.VatPercent, f => 17m)
                .RuleFor(i => i.Vat, (f, x) => x.DocTotal * x.VatPercent / 100)
                .RuleFor(i => i.DiscountPercent, f => Math.Round(f.Random.Decimal(0, 30), 2))
                .RuleFor(i => i.TotalDiscountAndRounding,
                    (f, x) => Math.Round(x.DocTotal.Value * x.DiscountPercent.Value / 100, 2))
                .RuleFor(i => i.GrossProfit, (f, x) => Math.Round(f.Random.Decimal() * 0.5m * x.DocTotal.Value, 2))
                .RuleFor(i => i.CreationDateTime, (f, x) => f.Date.Past(1))
                .RuleFor(i => i.Date, (f, x) => x.CreationDateTime)
                .RuleFor(x => x.CustomerSn, f => f.PickRandom(customers).Key)
                .RuleFor(x => x.CustomerName, (f, x) => customers.FirstOrDefault(c => c.Key == x.CustomerSn)?.Name)
                .RuleFor(x => x.CustomerAddress, (f, x) => customers.FirstOrDefault(c => c.Key == x.CustomerSn)?.Name);

            await GetDocDb<TDocument>().AddRangeAsync(faker.Generate(count));
            await _dbContext.SaveChangesAsync();
        }

        private async Task<AccountBalanceRecordEntity[]> FakeBalances(IEnumerable<BusinessPartner> customers)
        {
            foreach (var c in customers)
            {
                var invoices = await _dbContext.Invoices.Where(x => x.CustomerSn == c.Key).ToListAsync();
                var creditNotes = await _dbContext.CreditNotes.Where(x => x.CustomerSn == c.Key).ToListAsync();
                var records = invoices.Union<DocumentHeaderEntity>(creditNotes).Select(
                    x => new AccountBalanceRecordEntity
                    {
                        OwnerSn = c.Key,
                        Doc1Sn = x.Sn.ToString(),
                        Doc2Sn = x is IDocumentEntity entity
                            ? entity.Items.FirstOrDefault(i => i.BaseDoc?.DocKey != null)?.ToString()
                            : default,
                        Date = x.CreationDateTime ?? default,
                        Debt = x.DocTotal ?? default,
                        BalanceDebt = x.ToPay ?? 0,
                        Currency = x.Currency,
                        Type = x is InvoiceEntity
                            ? AccountBalanceRecordEntity.DocumentTypes.Invoice
                            : AccountBalanceRecordEntity.DocumentTypes.CreditInvoice
                    }).ToArray();

//                var receiptRecords = invoices
//                    .Where(x => x.Items.Any(i => i.FollowDoc.DocType == DocItemEntity.DocType.Receipt))
//                    .Select(x => new AccountBalanceRecordEntity
//                    {
//                        OwnerSn = c.Cid,
//                        Doc1Sn = x.Sn.ToString(),
//                        Doc2Sn = x.Items.FirstOrDefault(i => i.BaseDoc?.DocKey != null)?.ToString(),
//                        Date = x.CreationDateTime ?? default,
//                        Debt = x.DocTotal ?? default,
//                        BalanceDebt = 0,
//                        Currency = x.Currency,
//                        Type = AccountBalanceRecordEntity.DocumentTypes.Receipt
//                    })?.ToArray()??new  AccountBalanceRecordEntity[0];

                //  records = records.Union(receiptRecords).ToArray();
                c.Balance = records.Sum(x => x.BalanceDebt);
                _dbContext.BusinessPartners.Update(c);
                await _dbContext.AccountBalanceRecords.AddRangeAsync(records);
            }

            await _dbContext.SaveChangesAsync();
            return await _dbContext.AccountBalanceRecords.ToArrayAsync();
        }


        private DbSet<TDocument> GetDocDb<TDocument>() where TDocument : DocumentHeaderEntity, IDocumentEntity
        {
            return _dbContext.GetType().GetProperties()
                .FirstOrDefault(p => p.PropertyType == typeof(DbSet<TDocument>))
                ?.GetValue(_dbContext) as DbSet<TDocument>;
        }

        private async Task<UserLocation[]> FakeLastLocation(IEnumerable<EmployeeEntity> employees, int count = 100)
        {
            var faker = new Faker<UserLocation>()
                .RuleFor(x => x.Latitude, f => f.Address.Latitude())
                .RuleFor(x => x.Longitude, f => f.Address.Longitude())
                .RuleFor(x => x.EmployeeSn, f => f.PickRandom(employees).Sn)
                .RuleFor(x => x.DateTime, f => f.Date.RecentOffset().LocalDateTime);
            _dbContext.UserLocations.AddRange(faker.Generate(count));
            await _dbContext.SaveChangesAsync();
            return await _dbContext.UserLocations.ToArrayAsync();
        }
    }
}