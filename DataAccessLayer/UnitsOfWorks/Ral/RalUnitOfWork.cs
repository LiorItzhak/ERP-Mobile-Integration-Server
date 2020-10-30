using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Impls.Ral;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using DataAccessLayer.Entities.Documents.Headers;

namespace DataAccessLayer.UnitsOfWorks.Ral
{
    public class RalUnitOfWork : IUnitOfWork
    {
        private readonly RalDbContext _dbContext;


        // private  DbContextOptions<RalDbContext> _options;

        public RalUnitOfWork(RalDbContext dbContext)
        {

            _dbContext = dbContext;
            BusinessPartners = new BusinessPartnerRepository(dbContext);
            Company = new CompanyRepository(dbContext);
            Employees = new EmployeesRepository(dbContext);
            Quotations = new DocumentRepository<QuotationEntity, QuotationHeaderEntity>(dbContext);
            Orders = new DocumentRepository<OrderEntity, OrderHeaderEntity>(dbContext);
            DeliveryNotes = new DocumentRepository<DeliveryNoteEntity, DeliveryNoteHeaderEntity>(dbContext);
            Invoices = new DocumentRepository<InvoiceEntity, InvoiceHeaderEntity>(dbContext);
            CreditNotes = new DocumentRepository<CreditNoteEntity, CreditNoteHeaderEntity>(dbContext);
            DownPaymentRequests = new DocumentRepository<DownPaymentRequest, DownPaymentRequestHeader>(dbContext);

            Salesmen = new SalesmanRepository(dbContext);
            ProductGroups = new ProductGroupRepository(dbContext);
            Products = new ProductRepository(dbContext);
            RefreshTokens = new AuthenticationRepository(dbContext);
            IdentityUsers = new IdentityUserRepository(dbContext);
            UserLocations = new UserLocationRepository(dbContext);
            LeadUsersData = new LeadUserDataRepository(dbContext);
            EmployeeTimeClocks = new EmployeeTimeClockRepository(dbContext);
            Activities = new ActivityRepository(dbContext);
            Attachments= new AttachmentRepository(dbContext);

        }

        public IBusinessPartnerRepository BusinessPartners { get; private set; }

        public ISalesmanRepository Salesmen { get; private set; }

        public IEmployeeRepository Employees { get; private set; }

        public ICompanyRepository Company { get; private set; }


        public IDocumentRepository<DownPaymentRequest, DownPaymentRequestHeader> DownPaymentRequests { get; }
        public IProductGroupRepository ProductGroups { get; private set; }
        public IProductRepository Products { get; private set; }
        public IUserLocationRepository UserLocations { get; }
        public IAuthenticationRepository RefreshTokens { get; }
        public ILeadUserDataRepository LeadUsersData { get; }
        public IEmployeeTimeClockRepository EmployeeTimeClocks { get; }
        public IActivityRepository Activities { get; }
        public IAttachmentRepository Attachments { get; }
        public IIdentityRepository IdentityUsers { get; }

        public IDocumentRepository<QuotationEntity, QuotationHeaderEntity> Quotations { get; private set; }

        public IDocumentRepository<OrderEntity, OrderHeaderEntity> Orders { get; private set; }

        public IDocumentRepository<DeliveryNoteEntity, DeliveryNoteHeaderEntity> DeliveryNotes { get; private set; }

        public IDocumentRepository<InvoiceEntity, InvoiceHeaderEntity> Invoices { get; private set; }

        public IDocumentRepository<CreditNoteEntity, CreditNoteHeaderEntity> CreditNotes { get; private set; }

        public async Task<int> CompleteAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public IUnitOfWork CreateNew()
        {
            return new RalUnitOfWork(new RalDbContext(_dbContext.GetOptions()));
        }

        public void Dispose()
        {
            Console.WriteLine("RalDbContext Disposed");
        }
    }
}
