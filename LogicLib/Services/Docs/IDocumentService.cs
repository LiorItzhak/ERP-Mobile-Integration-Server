using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Entities.Documents.Headers;
using DataAccessLayer.Entities.Documents.Utils;

namespace LogicLib.Services.Docs
{
    public interface IDocumentService<TDocument, TDocumentHeader> where TDocumentHeader : DocumentHeaderEntity where TDocument : TDocumentHeader, IDocumentEntity
    {
        Task<IEnumerable<TDocumentHeader>> GetAllUpdatedAfterAsync(string cid, DateTime? modifiedAfter);

        Task<TDocument> GetByDocKeyAsync(int key);
        
        Task<TDocument> GetByDocNumberAsync(int docNumber);


        Task<TDocument> CreateNewDocument(TDocument document, CancellationToken cancellationToken);

        Task<TDocument> UpdateDocument(TDocument document, CancellationToken cancellationToken);

        Task<IEnumerable<TDocumentHeader>> GetAllBySalesmanAsync(int salesmanCode,bool? isOpen, DateTime? modifiedAfter = null);
        
        
        Task<IEnumerable<DocumentsSummery>> SumAsync(SumType type, DateTime fromDate , DateTime toDate,int? salesmanCode = null ,bool? isClosed = null);

    }

    public enum SumType { Monthly,Yearly,Daily }
}
