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
        Task<IEnumerable<TDocumentHeader>> GetPageAsync(
            string businessPartnerKey = null,
             int? salesmanKey = null,
             bool? isOpen = null,
             DateTime? modifiedAfter = null,
             int page = 0,
             int size = 10);
        

        Task<TDocument> GetByDocKeyAsync(int key);
        
        Task<TDocument> GetByDocNumberAsync(int docNumber);


        Task<TDocument> CreateNewDocument(TDocument document, CancellationToken cancellationToken);

        Task<TDocument> UpdateDocument(TDocument document, CancellationToken cancellationToken);

        
        
        Task<IEnumerable<DocumentsSummery>> SumAsync(SumType type, DateTime fromDate , DateTime toDate,int? salesmanCode = null ,bool? isClosed = null);

    }

    public enum SumType { Monthly,Yearly,Daily }
}
