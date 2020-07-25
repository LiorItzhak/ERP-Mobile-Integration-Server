using DataAccessLayer;
using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Entities.Documents.Headers;
using DataAccessLayer.Repositories;
using DataAccessLayer.UnitsOfWorks;
using LogicLib.Services.Docs;

namespace LogicLib.Services.Impl.Docs
{
    public class DownPaymentRequestsService: DocumentService<DownPaymentRequest, DownPaymentRequestHeader>,IDownPaymentRequestsService{
        public DownPaymentRequestsService(IDalService dalService) : base(dalService)
        {
        }

        protected override IDocumentRepository<DownPaymentRequest, DownPaymentRequestHeader> GetRepository(IUnitOfWork transaction)
        {
            return transaction.DownPaymentRequests;
        }
    
        
    }
}