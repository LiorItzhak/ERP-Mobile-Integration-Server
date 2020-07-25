using DataAccessLayer.Entities.Documents;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities.Documents.Headers;
using DataAccessLayer.Entities.Documents.Utils;

namespace DataAccessLayer.Repositories
{
    public interface IDocumentRepository<TDocument, TDocumentHeader> : IReadOnlyRepository<TDocumentHeader, int> where TDocumentHeader : DocumentHeaderEntity where TDocument : TDocumentHeader, IDocumentEntity
    {
        Task<TDocument> FindByIdWithItemsAsync(int docKey);

        Task<TDocument> UpdateAsync(TDocument document);

        Task<TDocument> AddAsync(TDocument document);

        Task<TDocument> CancelAsync(int docKey);

        Task<TDocument> CloseAsync(int docKey);
        
        Task<IEnumerable<DocumentsSummery>> SumMonthlyAsync(Expression<Func<TDocumentHeader, bool>> predicate = null);
        
        Task<IEnumerable<DocumentsSummery>> SumYearlyAsync(Expression<Func<TDocumentHeader, bool>> predicate= null);
        
        Task<IEnumerable<DocumentsSummery>> SumDailyAsync(Expression<Func<TDocumentHeader, bool>> predicate= null);

        Task CreatePdf(int docKey);


    }
}
