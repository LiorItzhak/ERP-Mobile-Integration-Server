using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Repositories;
using DataAccessLayer.UnitsOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities.Documents.Headers;
using LogicLib.Services.Impl.Docs;

namespace LogicLib.Services.Impl
{
    public class QuotationsService :  DocumentService<QuotationEntity, QuotationHeaderEntity> , IQuotationService
    {
        public QuotationsService(IDalService dalService) : base(dalService)
        {
        }

        public async Task<QuotationEntity> CancelDocument(int sn, CancellationToken cancellationToken)
        {
            using  (var transaction = DalService.CreateUnitOfWork())
            {
                var doc = await transaction.Quotations.FindByIdAsync(sn);

             
                var canceledDoc = await GetRepository(transaction).CancelAsync(sn);
                cancellationToken.ThrowIfCancellationRequested();
                await transaction.CompleteAsync();
                return canceledDoc;
            }
        }

        public async Task<QuotationEntity> CloseDocument(int sn, CancellationToken cancellationToken)
        {
            using (var transaction = DalService.CreateUnitOfWork())
            {
                var doc = await transaction.Quotations.FindByIdAsync(sn);


                var closedDoc = await GetRepository(transaction).CloseAsync(sn);
                cancellationToken.ThrowIfCancellationRequested();
                await transaction.CompleteAsync();
                return closedDoc;
            }
        }

        protected override IDocumentRepository<QuotationEntity, QuotationHeaderEntity> GetRepository(IUnitOfWork transaction)
        {
            return transaction.Quotations;
        }
    }
}
