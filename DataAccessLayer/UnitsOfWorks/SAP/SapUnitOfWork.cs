
using System;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;

using DataAccessLayer.SAPHandler.SqlHandler.Models;

using DataAccessLayer.SAPHandler.DiApiHandler;

using DataAccessLayer.SAPHandler;
using DataAccessLayer.Repositories.Impls.SAP;
using CrossLayersUtils.Aspects;
using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Entities.Documents.Headers;
using DataAccessLayer.Repositories.Impls.Ral;
using DataAccessLayer.SAPHandler.SqlHandler.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DataAccessLayer.UnitsOfWorks.SAP
{
    public class SapUnitOfWork : IUnitOfWork
    {
       private readonly SapDiApiContext _diApiContext;
       private readonly SapSqlDbContext _sapSqlDbContext;
       private readonly RalDbContext _extrasDbContext;
       public static IServiceProvider CurrentProvider;
       private readonly SapContextOptions _options;

       public SapUnitOfWork(SapContextOptions options)
        {
            //this.InjectInstanceOf(typeof(IRepository), sapSqlDbContext, diApiContext);
            //this.InjectInstanceOf(typeof(IRepository), sapSqlDbContext, diApiContext, options.SqlServerConnection, new DemoItemPropertiesRepository());
            var productPropertiesRepository = new DemoProductPropertiesRepository();
            _options = options;
            _extrasDbContext = new RalDbContext(options.ExtrasServerOptions);
            _diApiContext = new SapDiApiContext(options.DiApiServerConnection,CurrentProvider.GetService<ILogger<SapDiApiContext>>());
            _sapSqlDbContext = new SapSqlDbContext(options.SapSqlServerOptions);
            BusinessPartners = new SapBusinessPartnerRepository(_sapSqlDbContext, _diApiContext);
            Salesmen = new SapSalesmanRepository(_sapSqlDbContext, _diApiContext);
            Employees = new SapEmployeeRepository(_sapSqlDbContext, _diApiContext);
            Company = new SapCompanyRepository(_sapSqlDbContext, _diApiContext);
            Quotations = new SapDocumentRepository<QuotationEntity, QuotationHeaderEntity>(_sapSqlDbContext, _diApiContext, productPropertiesRepository);
            Orders = new SapDocumentRepository<OrderEntity, OrderHeaderEntity>(_sapSqlDbContext, _diApiContext, productPropertiesRepository);
            DeliveryNotes = new SapDocumentRepository<DeliveryNoteEntity, DeliveryNoteHeaderEntity>(_sapSqlDbContext, _diApiContext,productPropertiesRepository);
            Invoices = new SapDocumentRepository<InvoiceEntity, InvoiceHeaderEntity>(_sapSqlDbContext, _diApiContext,  productPropertiesRepository);
            CreditNotes = new SapDocumentRepository<CreditNoteEntity, CreditNoteHeaderEntity>(_sapSqlDbContext, _diApiContext,productPropertiesRepository);
            DownPaymentRequests = new SapDocumentRepository<DownPaymentRequest, DownPaymentRequestHeader>(_sapSqlDbContext, _diApiContext,productPropertiesRepository);

            ProductGroups = new SapProductGroupRepository(_sapSqlDbContext, _diApiContext);
            Products = new SapProductRepository(_sapSqlDbContext, _diApiContext);
            RefreshTokens = new AuthenticationRepository(_extrasDbContext);
            UserLocations = new UserLocationRepository(_extrasDbContext);
            LeadUsersData = new LeadUserDataRepository(_extrasDbContext);
            EmployeeTimeClocks = new  EmployeeTimeClockRepository(_extrasDbContext);
            _activities = new Lazy<IActivityRepository>( new SapActivityRepository(_sapSqlDbContext, _diApiContext,_extrasDbContext,options));
            _attachments =  new Lazy<IAttachmentRepository>(new SapAttachmentRepository(_sapSqlDbContext, _diApiContext));
            _identityUsers = new Lazy<IIdentityRepository>(new IdentityUserRepository(_extrasDbContext));
        }


        public IBusinessPartnerRepository BusinessPartners { get;}

        public ISalesmanRepository Salesmen { get; }

        public IEmployeeRepository Employees { get;  }

        public ICompanyRepository Company { get; }

        public IDocumentRepository<QuotationEntity, QuotationHeaderEntity> Quotations { get; }

        public IDocumentRepository<OrderEntity, OrderHeaderEntity> Orders { get; }

        public IDocumentRepository<DeliveryNoteEntity, DeliveryNoteHeaderEntity> DeliveryNotes { get; }

        public IDocumentRepository<InvoiceEntity, InvoiceHeaderEntity> Invoices { get;  }

        public IDocumentRepository<CreditNoteEntity, CreditNoteHeaderEntity> CreditNotes { get;  }
        public IDocumentRepository<DownPaymentRequest, DownPaymentRequestHeader> DownPaymentRequests { get; }

        public IProductGroupRepository ProductGroups { get;}

        public IProductRepository Products { get;  }
        public IUserLocationRepository UserLocations { get; }

        public IAuthenticationRepository RefreshTokens { get; }
        public ILeadUserDataRepository LeadUsersData { get; }
        public IEmployeeTimeClockRepository EmployeeTimeClocks { get; }
        private readonly Lazy<IActivityRepository> _activities;
        public IActivityRepository Activities => _activities.Value;
        private readonly Lazy<IAttachmentRepository> _attachments;
        public IAttachmentRepository Attachments => _attachments.Value;
        
        private readonly Lazy<IIdentityRepository> _identityUsers;
        public IIdentityRepository IdentityUsers => _identityUsers.Value;


        [LogMethod(After = "Transaction Completed, all changes are saved!")]
        public async Task<int>CompleteAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return (await _extrasDbContext.SaveChangesAsync(cancellationToken)) + _diApiContext.SaveChanges() ;
        }

        [LogMethod(Before = "Create New Transaction")]
        public IUnitOfWork CreateNew()
        {
            return new SapUnitOfWork(_options);
        }
        [LogMethod(Before = "Transaction Disposed, rollback!")]
        public void Dispose()
        {
            _extrasDbContext.Dispose();
            _diApiContext.Dispose();
            _sapSqlDbContext.Dispose();
        }

    }
}
