using DataAccessLayer.Repositories;
using CrossLayersUtils.Aspects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Entities.Documents.Headers;

namespace DataAccessLayer.UnitsOfWorks
{
    public interface IReadOnlyUnitOfWork : IDisposable 
    {
        IBusinessPartnerRepository BusinessPartners { get; }
        ISalesmanRepository Salesmen { get; }
        IEmployeeRepository Employees { get; }
        ICompanyRepository Company { get; }

        IDocumentRepository<QuotationEntity, QuotationHeaderEntity> Quotations { get; }
        IDocumentRepository<OrderEntity, OrderHeaderEntity> Orders { get; }
        IDocumentRepository<DeliveryNoteEntity, DeliveryNoteHeaderEntity> DeliveryNotes { get; }
        IDocumentRepository<InvoiceEntity, InvoiceHeaderEntity> Invoices { get; }
        IDocumentRepository<CreditNoteEntity, CreditNoteHeaderEntity> CreditNotes { get; }
        
        IDocumentRepository<DownPaymentRequest, DownPaymentRequestHeader> DownPaymentRequests { get; }


        IProductGroupRepository ProductGroups { get;  }
        IProductRepository Products { get;  }
        IUserLocationRepository UserLocations { get; }
        IAuthenticationRepository RefreshTokens { get;  }
        ILeadUserDataRepository LeadUsersData { get;  }

        IEmployeeTimeClockRepository EmployeeTimeClocks{ get;  }
        
        IActivityRepository Activities { get; }
        
        IAttachmentRepository Attachments { get; }
        IIdentityRepository IdentityUsers { get; }
        

    }
    public interface IUnitOfWork : IReadOnlyUnitOfWork
    {
        // IIdentityRepository IdentityUsers { get; }
        Task<int> CompleteAsync(CancellationToken cancellationToken = default);
        IUnitOfWork CreateNew();
        

        
    }
}
