using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using CrossLayersUtils;
using CrossLayersUtils.Utils;
using DataAccessLayer;
using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Entities.Documents.Headers;
using DataAccessLayer.Entities.Documents.Utils;
using DataAccessLayer.Repositories;
using DataAccessLayer.UnitsOfWorks;
using LogicLib.Services.Docs;
using Microsoft.EntityFrameworkCore.Internal;

namespace LogicLib.Services.Impl.Docs
{
    public abstract class DocumentService<TDocument, TDocumentHeader> : IDocumentService<TDocument, TDocumentHeader>
        where TDocumentHeader : DocumentHeaderEntity where TDocument : TDocumentHeader, IDocumentEntity
    {
        protected readonly IDalService DalService;

        protected DocumentService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<TDocument> GetByDocNumberAsync(int docNumber)
        {
            using var transaction = DalService.CreateUnitOfWork();
            var header = await GetRepository(transaction).SingleOrDefaultAsync(x => x.Sn == docNumber);
            if (header?.Key == null) throw new NotFoundException($"Document:{docNumber} don't exist");
            return await GetByDocKeyAsync(header.Key.Value);
        }

        public async Task<TDocument> CreateNewDocument(TDocument document, CancellationToken cancellationToken)
        {
            if (document.Key.HasValue)
                throw new InvalidStateException("Document already have a key");
            using var transaction = DalService.CreateUnitOfWork();
            document.CreationDateTime = null; //determine by ERP 
            document.DocTotal = null; //determine by ERP 
            document.Vat = null; //determine by ERP 
            document.TotalDiscountAndRounding = null; //determine by ERP 
            var addedDoc = await GetRepository(transaction).AddAsync(document);
            await transaction.CompleteAsync(cancellationToken);
            return addedDoc;
        }
        

        public async Task<IEnumerable<DocumentsSummery>> SumAsync(SumType type, DateTime fromDate, DateTime toDate,
            int? salesmanCode = null, bool? isClosed = null)
        {
            if (type != SumType.Monthly)
                throw new InvalidStateException($"Unsupported type {type} Not Implemented");
            using var transaction = DalService.CreateUnitOfWork();
            Expression<Func<TDocumentHeader, bool>> datePredicate =
                x => x.Date >= fromDate && x.Date <= toDate && x.IsCanceled != true;

            Expression<Func<TDocumentHeader, bool>> salesmanPredicate =
                x => x.SalesmanSn == salesmanCode && x.Date >= fromDate && x.Date <= toDate && x.IsCanceled != true;

            Expression<Func<TDocumentHeader, bool>> isClosedPredicate =
                x => x.IsClosed == isClosed && x.Date >= fromDate && x.Date <= toDate && x.IsCanceled != true;

            Expression<Func<TDocumentHeader, bool>> isClosedSalesmanPredicate =
                x => x.IsClosed == isClosed && x.SalesmanSn == salesmanCode && x.Date >= fromDate &&
                     x.Date <= toDate && x.IsCanceled != true;

            Expression<Func<TDocumentHeader, bool>> predicate;
            if (salesmanCode.HasValue && isClosed.HasValue)
                predicate = isClosedSalesmanPredicate;
            else if (salesmanCode.HasValue)
                predicate = salesmanPredicate;
            else if (isClosed.HasValue)
                predicate = isClosedPredicate;
            else
                predicate = datePredicate;

            return await GetRepository(transaction).SumMonthlyAsync(predicate);
        }



        public async Task<IEnumerable<TDocumentHeader>> GetPageAsync(string businessPartnerKey = null,
            int? salesmanKey = null, bool? isOpen = null,
            DateTime? modifiedAfter = null, int page = 0, int size = 10)
        {
            using var transaction = DalService.CreateUnitOfWork();
            var docs = await GetRepository(transaction).FindAllAsync(
                d =>
                    (businessPartnerKey != null && d.CustomerSn == businessPartnerKey) ||
                    (salesmanKey != null && d.SalesmanSn == salesmanKey) ||
                    (isOpen.HasValue && d.IsClosed != isOpen.Value) ||
                    (modifiedAfter.HasValue && (d.LastUpdateDateTime ?? d.CreationDateTime) > modifiedAfter),
                PageRequest.Of(page, size, Sort<TDocumentHeader>.By(x => x.Sn)));

            return docs;
        }

        public async Task<TDocument> GetByDocKeyAsync(int key)
        {
            using var transaction = DalService.CreateUnitOfWork();
            var doc = await GetRepository(transaction).FindByIdWithItemsAsync(key);
            if (doc == null) throw new NotFoundException($"Document with key:{key} don't exist");
            return doc;
        }

        public async Task<TDocument> UpdateDocument(TDocument document, CancellationToken cancellationToken)
        {
            if (!document.Key.HasValue) throw new InvalidStateException("Can't update document without a key");
            using var transaction = DalService.CreateUnitOfWork();
            document.CreationDateTime = null; //determine by ERP 
            document.DocTotal = null; //determine by ERP 
            document.Vat = null; //determine by ERP 
            document.TotalDiscountAndRounding = null; //determine by ERP 
            var addedDoc = await GetRepository(transaction).UpdateAsync(document);
            await transaction.CompleteAsync(cancellationToken);
            return addedDoc;
        }

        protected abstract IDocumentRepository<TDocument, TDocumentHeader> GetRepository(IUnitOfWork transaction);
    }
}