using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Entities.Documents.Headers;

namespace LogicLib.Services.Docs
{
    public interface IDownPaymentRequestsService : IDocumentService<DownPaymentRequest, DownPaymentRequestHeader>
    {
        
    }
}