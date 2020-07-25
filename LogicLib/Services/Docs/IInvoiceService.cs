using DataAccessLayer.Entities.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities.Documents.Headers;

namespace LogicLib.Services.Docs
{
    public interface IInvoiceService : IDocumentService<InvoiceEntity, InvoiceHeaderEntity>
    {
    }
}
