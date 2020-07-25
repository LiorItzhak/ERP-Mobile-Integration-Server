using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Repositories;
using DataAccessLayer.UnitsOfWorks;
using LogicLib.Services.Docs;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using DataAccessLayer.Entities.Documents.Headers;

namespace LogicLib.Services.Impl.Docs
{
    public class InvoicesService : DocumentService<InvoiceEntity, InvoiceHeaderEntity>, IInvoiceService
    {
        public InvoicesService(IDalService dalService) : base(dalService)
        {
        }

        protected override IDocumentRepository<InvoiceEntity, InvoiceHeaderEntity> GetRepository(IUnitOfWork transaction)
        {
            return transaction.Invoices;
        }
    }
}
