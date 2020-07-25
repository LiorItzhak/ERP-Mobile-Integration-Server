using JetBrains.Annotations;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Documents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities.Authentication;
using DataAccessLayer.Entities.BusinessPartners;
using DataAccessLayer.Entities.Documents.Headers;
using DataAccessLayer.Entities.Documents.Items;
using Innofactor.EfCoreJsonValueConverter;
using DataAccessLayer.Entities.Products;
using DataAccessLayer.Entities.UserData;

namespace DataAccessLayer.Repositories.Impls.Ral
{
    public class RalDbContext : DbContext

    {
        private readonly DbContextOptions<RalDbContext> _options;

        public RalDbContext(DbContextOptions<RalDbContext> options) : base(options)
        {
            _options = options;
        }


        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<BusinessPartner> BusinessPartners { get; set; }
        public DbSet<SalesmanEntity> Salesmen { get; set; }

        public DbSet<EmployeeEntity> Employees { get; set; }

        // public DbSet<DocItemEntity> DocItems { get; set; }
        public DbSet<QuotationEntity> Quotations { get; set; }
        public DbSet<InvoiceEntity> Invoices { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<CreditNoteEntity> CreditNotes { get; set; }
        public DbSet<DeliveryNoteEntity> DeliveryNotes { get; set; }
        public DbSet<DownPaymentRequest > DownPaymentRequests { get; set; }

        public DbSet<AccountBalanceRecordEntity> AccountBalanceRecords { get; set; }
        public DbSet<CardGroup> CardGroups { get; set; }
        public DbSet<Indicator> CardIndicators { get; set; }
        public DbSet<Industry> CardIndustries{ get; set; }


        public DbSet<ProductGroupEntity> ProductGroups { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        
        public DbSet<IdentityUser> IdentityUsers { get; set; }
        public DbSet<UserLocation> UserLocations { get; set; }

        public DbSet<UserData> LeadUserData { get; set; }

        public DbSet<EmployeeTimeClock> EmployeeTimeClocks { get; set; }
        public DbSet<Activity> Activities { get; set; }

        public DbSet<ActivitySubject> ActivitySubjects { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        
        public DbSet<Attachment> Attachments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO NEASTED TABELS INSTEAD OF JSON
            modelBuilder.Entity<DocItemEntity>()
                .HasKey(i => new {i.DocKey, i.ItemNumber});
            modelBuilder.Entity<DocItemEntity>()
                .Property(i => i.Properties)
                .HasJsonValueConversion();

            modelBuilder.Entity<DocItemEntity>()
                .Property(i => i.BaseDoc)
                .HasJsonValueConversion();
            modelBuilder.Entity<DocItemEntity>()
                .Property(i => i.FollowDoc)
                .HasJsonValueConversion();

            modelBuilder.Entity<ProductEntity>()
                .Property(i => i.Properties)
                .HasJsonValueConversion();


            modelBuilder.Entity<InvoiceEntity>()
                .Property(i => i.Items)
                .HasJsonValueConversion();
            modelBuilder.Entity<QuotationEntity>()
                .Property(i => i.Items)
                .HasJsonValueConversion();
            modelBuilder.Entity<OrderEntity>()
                .Property(i => i.Items)
                .HasJsonValueConversion();
            modelBuilder.Entity<DeliveryNoteEntity>()
                .Property(i => i.Items)
                .HasJsonValueConversion();
            modelBuilder.Entity<CreditNoteEntity>()
                .Property(i => i.Items)
                .HasJsonValueConversion();


            modelBuilder.Entity<BusinessPartner>()
                .Property(i => i.BillingAddress)
                .HasJsonValueConversion();
            modelBuilder.Entity<BusinessPartner>()
                .Property(i => i.ShippingAddress)
                .HasJsonValueConversion();

            modelBuilder.Entity<ProductEntity>()
                .Property(x => x.SellPriceList)
                .HasJsonValueConversion();
            modelBuilder.Entity<ProductEntity>()
                .Property(x => x.BuyPriceList)
                .HasJsonValueConversion();
            
            modelBuilder.Entity<CompanyEntity>()
                .Property(x => x.BankAccount)
                .HasJsonValueConversion();
            modelBuilder.Entity<BusinessPartner>()
                .Property(x => x.GeoLocation)
                .HasJsonValueConversion();
            
            
            //LeadUserData
            modelBuilder.Entity<UserData>()
                .HasKey(i => new {i.UserId, i.LeadSn});
            //////////
            
            
            //EmployeeTimeClock
            modelBuilder.Entity<EmployeeTimeClock>()
                .Property(x => x.Properties)
                .HasJsonValueConversion();
            modelBuilder.Entity<EmployeeTimeClock>()
                .Property(x => x.CheckInLocation)
                .HasJsonValueConversion();
            modelBuilder.Entity<EmployeeTimeClock>()
                .Property(x => x.CheckOutLocation)
                .HasJsonValueConversion();

//            modelBuilder.Entity<OrderEntity>()
//                .Property(x => x.Sn)
//                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Activity>()
                .Property(i => i.Document)
                .HasJsonValueConversion();


            modelBuilder.Entity<Attachment>()
                .HasKey(x => new {x.AttachmentsCode, x.Num});
            
            
            modelBuilder.Entity<UserLocation>()
                .Property(i => i.MetaData)
                .HasJsonValueConversion();
        }


        public DbContextOptions<RalDbContext> GetOptions()
        {
            return _options;
        }
    }
}