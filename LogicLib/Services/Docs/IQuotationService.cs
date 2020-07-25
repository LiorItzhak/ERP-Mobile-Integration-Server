using DataAccessLayer.Entities.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Entities.Documents.Headers;
using LogicLib.Services.Docs;

namespace LogicLib.Services
{
    public interface IQuotationService :IDocumentService<QuotationEntity, QuotationHeaderEntity>
    {
        Task<QuotationEntity> CancelDocument(int sn, CancellationToken cancellationToken);
        Task<QuotationEntity> CloseDocument(int sn, CancellationToken cancellationToken);


    }
}
