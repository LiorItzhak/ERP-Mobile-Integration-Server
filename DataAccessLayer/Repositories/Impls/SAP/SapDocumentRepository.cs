using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccessLayer.SAPHandler.SqlHandler.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DataAccessLayer.SAPHandler.DiApiHandler;
using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Entities.Documents.Headers;
using DataAccessLayer.Entities.Documents.Items;
using DataAccessLayer.Entities.Documents.Utils;
using DataAccessLayer.SAPHandler.DiApiHandler.SapDbSets;
using DataAccessLayer.SAPHandler.SqlHandler.DbContexts;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer.Repositories.Impls.SAP
{
    public class SapDocumentRepository<TDocument, TDocumentHeader> :
        SapReadOnlyRepository<TDocumentHeader, int>, IDocumentRepository<TDocument, TDocumentHeader>
        where TDocumentHeader : DocumentHeaderEntity where TDocument : TDocumentHeader, IDocumentEntity

    {
        private readonly SapSqlDbContext _dbContext;
        private readonly SapDiApiContext _diApiContext;
        private readonly IProductPropertiesRepository _itemPropertiesRepository;
        private readonly string _connectionString;
        private readonly Type _docType;


        public SapDocumentRepository(SapSqlDbContext dbContext, SapDiApiContext diApiContext,
            IProductPropertiesRepository propertiesRepository)
            : base(SelectDocumentHeaderFromDb(dbContext), x => x.Key.Value)
        {
            _dbContext = dbContext;
            _diApiContext = diApiContext;
            _connectionString = _dbContext.Database.GetDbConnection().ConnectionString;
            _itemPropertiesRepository = propertiesRepository;
            _docType = typeof(TDocument);
        }


        public Task<TDocument> AddAsync(TDocument document)
        {
            return Task.Run(() => GetDiSet().Add(document));
        }

        public Task<TDocument> CancelAsync(int docKey)
        {
            return Task.Run(() => GetDiSet().Cancel(docKey));
        }

        public Task<TDocument> CloseAsync(int docKey)
        {
            return Task.Run(() => GetDiSet().Close(docKey));
        }

        public Task<TDocument> UpdateAsync(TDocument document)
        {
            return Task.Run(() => GetDiSet().Update(document));
        }


        public async Task<TDocument> FindByIdWithItemsAsync(int docKey)
        {
            //get document header from SQL db
            var doc = await SelectDocumentWithNoItemsFromDb().SingleOrDefaultAsync(d => d.Key == docKey);
            if (doc?.Key == null)
                return null;
            //get a list of the items that belong to the document 
            var temp = (await GetDocumentItemsFromDb(doc.Key.Value)
                .ToArrayAsync());
            doc.Items = temp.Select(itm =>
            {
                itm.DocKey = docKey;
                return itm;
            }).ToList();
            //get a matching item's properties
            var itemProperties = doc.Items
                .Select(i => new
                    {LineNumber = i.ItemNumber, Properties = _itemPropertiesRepository.FindProperties(i.Code)})
                .ToDictionary(t => t.LineNumber.Value, t => t.Properties);

            //get the properties of the items

            using (var cnn = new SqlConnection(_connectionString))
            {
                var sqlCmd = $"Select * from {GetDocItemsTableName()} where DocEntry = @docEntry";
                cnn.Open();
                var command = new SqlCommand(sqlCmd, cnn);
                command.Parameters.AddWithValue("@docEntry", doc.Key.Value);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    doc.Items
                            .Single(i => i.ItemNumber == (int) dataReader["LineNum"]).Properties =
                        itemProperties[(int) dataReader["LineNum"]]
                            .ToDictionary(p => p.Value, p => dataReader[p.Key]);
                }

                dataReader.Close();
                command.Dispose();
            }

            return doc;
        }


        public async Task<IEnumerable<DocumentsSummery>> SumMonthlyAsync(
            Expression<Func<TDocumentHeader, bool>> predicate)
        {
            var temp = SelectDocumentHeaderFromDb(_dbContext);
            if (predicate != null)
                temp = temp.Where(predicate);

            return await temp
                .GroupBy(x => new {Year = x.Date.Value.Year, Month = x.Date.Value.Month})
                .Select(x => new DocumentsSummery
                {
                    Year = x.Key.Year,
                    Month = x.Key.Month,
                    Count = x.Count(),
                    TotalVat = x.Sum(doc => doc.Vat).GetValueOrDefault(),
                    TotalGrossProfit = x.Sum(doc => doc.GrossProfit).GetValueOrDefault(),
                    TotalWithVat = x.Sum(doc => doc.DocTotal).GetValueOrDefault(),
                    TotalToPay = x.Sum(doc => doc.ToPay).GetValueOrDefault(),
                }).ToListAsync();
        }

        public Task<IEnumerable<DocumentsSummery>> SumYearlyAsync(Expression<Func<TDocumentHeader, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DocumentsSummery>> SumDailyAsync(Expression<Func<TDocumentHeader, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task CreatePdf(int docKey)
        {
            await Task.Run(() => GetDiSet(_docType).CreatePdf(docKey));
        }


        private static readonly Expression<Func<TDocumentHeader, DocumentsSummery>> AsDocumentsSummery =
            x => new DocumentsSummery
            {
            };


        private IDocumentDiSet<TDocument> GetDiSet(Type entityType = null)
        {
            var docType = entityType != null ? entityType : _docType;
            if (docType == (typeof(QuotationEntity)))
                return _diApiContext.Quotations as IDocumentDiSet<TDocument>;
            if (docType == (typeof(OrderEntity)))
                return _diApiContext.Orders as IDocumentDiSet<TDocument>;
            if (docType == (typeof(DeliveryNoteEntity)))
                return _diApiContext.DeliveryNotes as IDocumentDiSet<TDocument>;
            if (docType == (typeof(InvoiceEntity)))
                return _diApiContext.Invoices as IDocumentDiSet<TDocument>;
            if (docType == (typeof(CreditNoteEntity)))
                return _diApiContext.CreditNotes as IDocumentDiSet<TDocument>;
            if (docType == (typeof(DownPaymentRequest)))
                return _diApiContext.DownPaymentRequests as IDocumentDiSet<TDocument>;
            throw new Exception($"Generic type {_docType} invalid for DocumentHeaderRepository");
        }

        private IQueryable<DocItemEntity> GetDocumentItemsFromDb(int docEntry)
        {
            if (_docType == (typeof(QuotationEntity)))
                return _dbContext.QUT1.Where(i => i.DocEntry == docEntry).Select(AsDocItemEntityQUT1);
            if (_docType == (typeof(OrderEntity)))
                return _dbContext.RDR1.Where(i => i.DocEntry == docEntry).Select(AsDocItemEntityRdr1);
            if (_docType == (typeof(DeliveryNoteEntity)))
                return _dbContext.DLN1.Where(i => i.DocEntry == docEntry).Select(AsDocItemEntityDLN1);
            if (_docType == (typeof(InvoiceEntity)))
                return _dbContext.INV1.Where(i => i.DocEntry == docEntry).Select(AsDocItemEntityInv1);
            if (_docType == (typeof(CreditNoteEntity)))
                return _dbContext.RIN1.Where(i => i.DocEntry == docEntry).Select(AsDocItemEntityRin1);
            if (_docType == (typeof(DownPaymentRequest)))
                return _dbContext.DPI1.Where(i => i.DocEntry == docEntry).Select(AsDocItemEntityDpi1);
            throw new Exception($"Generic type {_docType} invalid for DocumentHeaderRepository");
        }

        private string GetDocItemsTableName()
        {
            if (_docType == typeof(QuotationEntity))
                return nameof(QUT1);
            if (_docType == typeof(OrderEntity))
                return nameof(RDR1);
            if (_docType == typeof(DeliveryNoteEntity))
                return nameof(DLN1);
            if (_docType == typeof(InvoiceEntity))
                return nameof(INV1);
            if (_docType == typeof(CreditNoteEntity))
                return nameof(RIN1);
            if (_docType == typeof(DownPaymentRequest))
                return nameof(DPI1);
            throw new Exception($"Generic type {_docType} invalid for DocumentHeaderRepository");
        }


        private IQueryable<TDocument> SelectDocumentWithNoItemsFromDb()
        {
            var docType = typeof(TDocument);
            if (docType == (typeof(QuotationEntity)))
                return _dbContext.OQUT.Select(AsQuotationHeaderEntity) as IQueryable<TDocument>;
            if (docType == (typeof(OrderEntity)))
                return _dbContext.ORDR.Select(AsOrderHeaderEntity) as IQueryable<TDocument>;
            if (docType == (typeof(DeliveryNoteEntity)))
                return _dbContext.ODLN.Select(AsDeliveryNoteHeaderEntity) as IQueryable<TDocument>;
            if (docType == (typeof(InvoiceEntity)))
                return _dbContext.OINV.Select(AsInvoiceHeaderEntity) as IQueryable<TDocument>;
            if (docType == (typeof(CreditNoteEntity)))
                return _dbContext.ORIN.Select(AsCreditNoteHeaderEntity) as IQueryable<TDocument>;
            if (docType == (typeof(DownPaymentRequest)))
                return _dbContext.ODPI.Select(AsDownPaymentRequestHeader) as IQueryable<TDocument>;
            throw new Exception($"Generic type {docType} invalid for DocumentHeaderRepository");
        }

        private static IQueryable<TDocumentHeader> SelectDocumentHeaderFromDb(SapSqlDbContext dbContext)
        {
            var docType = typeof(TDocument);
            if (docType == (typeof(QuotationEntity)))
                return dbContext.OQUT.Select(AsQuotationHeaderEntity) as IQueryable<TDocumentHeader>;
            if (docType == (typeof(OrderEntity)))
                return dbContext.ORDR.Select(AsOrderHeaderEntity) as IQueryable<TDocumentHeader>;
            if (docType == (typeof(DeliveryNoteEntity)))
                return dbContext.ODLN.Select(AsDeliveryNoteHeaderEntity) as IQueryable<TDocumentHeader>;
            if (docType == (typeof(InvoiceEntity)))
                return dbContext.OINV.Select(AsInvoiceHeaderEntity) as IQueryable<TDocumentHeader>;
            if (docType == (typeof(CreditNoteEntity)))
                return dbContext.ORIN.Select(AsCreditNoteHeaderEntity) as IQueryable<TDocumentHeader>;
            if (docType == (typeof(DownPaymentRequest)))
                return dbContext.ODPI.Select(AsDownPaymentRequestHeader) as IQueryable<TDocumentHeader>;

            throw new Exception($"Generic type {docType} invalid for DocumentHeaderRepository");
        }


        private static readonly Expression<Func<OQUT, QuotationEntity>> AsQuotationHeaderEntity =
            x => new QuotationEntity
            {
                Key = x.DocEntry,
                Sn = x.DocNum,
                ExternalSn = x.NumAtCard,
                CustomerSn = x.CardCode,
                CustomerName = x.CardName,
                CustomerAddress = x.Address,
                CustomerFederalTaxId = x.LicTradNum,

                IsClosed = x.DocStatus == "C",
                IsCanceled = x.CANCELED == "Y",

                Date = x.DocDate,

                CreationDateTime = x.CreateTS.HasValue && x.CreateDate.HasValue ? x.CreateDate.Value
                    .AddSeconds( x.CreateTS.Value % 100)
                    .AddMinutes(( x.CreateTS.Value / 100) % 100)
                    .AddHours(( x.CreateTS.Value / 10000) % 10000) : x.CreateDate,
                
                LastUpdateDateTime = x.UpdateTS.HasValue && x.UpdateDate.HasValue ? x.UpdateDate.Value
                    .AddSeconds( x.UpdateTS.Value % 100)
                    .AddMinutes(( x.UpdateTS.Value / 100) % 100)
                    .AddHours(( x.UpdateTS.Value / 10000) % 10000) : x.UpdateDate,

                ClosingDate = x.ClsDate,
                ValidUntil = x.DocDueDate,

                Comments = x.Comments,

                SalesmanSn = x.SlpCode,
                OwnerEmployeeSn = x.OwnerCode,

                Currency = x.DocCur,
                DocTotal = x.DocTotal.Value,
                DiscountPercent = x.DiscPrcnt.Value,
                VatPercent = x.VatPercent.Value,
                Vat = x.VatSum,
                TotalDiscountAndRounding = x.DiscSum,
                ToPay = x.DocTotal - x.PaidToDate,
                GrossProfit = x.GrosProfit,
                AttachmentsCode = x.AtcEntry
            };


        private static readonly Expression<Func<ORDR, OrderEntity>> AsOrderHeaderEntity =
            x => new OrderEntity
            {
                Key = x.DocEntry,
                Sn = x.DocNum,
                ExternalSn = x.NumAtCard,
                CustomerSn = x.CardCode,
                CustomerName = x.CardName,
                CustomerAddress = x.Address,
                CustomerFederalTaxId = x.LicTradNum,

                IsClosed = x.DocStatus == "C",
                IsCanceled = x.CANCELED == "Y",

                Date = x.DocDate,
                CreationDateTime = x.CreateTS.HasValue && x.CreateDate.HasValue ? x.CreateDate.Value
                    .AddSeconds( x.CreateTS.Value % 100)
                    .AddMinutes(( x.CreateTS.Value / 100) % 100)
                    .AddHours(( x.CreateTS.Value / 10000) % 10000) : x.CreateDate,
                
                LastUpdateDateTime = x.UpdateTS.HasValue && x.UpdateDate.HasValue ? x.UpdateDate.Value
                    .AddSeconds( x.UpdateTS.Value % 100)
                    .AddMinutes(( x.UpdateTS.Value / 100) % 100)
                    .AddHours(( x.UpdateTS.Value / 10000) % 10000) : x.UpdateDate,
                
      
                ClosingDate = x.ClsDate,
                SupplyDate = x.DocDueDate,

                Comments = x.Comments,

                SalesmanSn = x.SlpCode,
                OwnerEmployeeSn = x.OwnerCode,

                Currency = x.DocCur,
                DocTotal = x.DocTotal.Value,
                DiscountPercent = x.DiscPrcnt.Value,
                VatPercent = x.VatPercent.Value,
                Vat = x.VatSum,
                TotalDiscountAndRounding = x.DiscSum,
                ToPay = x.DocTotal - x.PaidToDate,
                GrossProfit = x.GrosProfit,
                AttachmentsCode = x.AtcEntry
            };

        private static readonly Expression<Func<ODLN, DeliveryNoteEntity>> AsDeliveryNoteHeaderEntity =
            x => new DeliveryNoteEntity
            {
                Key = x.DocEntry,
                Sn = x.DocNum,
                ExternalSn = x.NumAtCard,
                CustomerSn = x.CardCode,
                CustomerName = x.CardName,
                CustomerAddress = x.Address,
                CustomerFederalTaxId = x.LicTradNum,

                IsClosed = x.DocStatus == "C",
                IsCanceled = x.CANCELED == "Y",

                Date = x.DocDate,
                CreationDateTime = x.CreateTS.HasValue && x.CreateDate.HasValue ? x.CreateDate.Value
                    .AddSeconds( x.CreateTS.Value % 100)
                    .AddMinutes(( x.CreateTS.Value / 100) % 100)
                    .AddHours(( x.CreateTS.Value / 10000) % 10000) : x.CreateDate,
                
                LastUpdateDateTime = x.UpdateTS.HasValue && x.UpdateDate.HasValue ? x.UpdateDate.Value
                    .AddSeconds( x.UpdateTS.Value % 100)
                    .AddMinutes(( x.UpdateTS.Value / 100) % 100)
                    .AddHours(( x.UpdateTS.Value / 10000) % 10000) : x.UpdateDate,
                ClosingDate = x.ClsDate,
                SupplyDate = x.DocDueDate,

                Comments = x.Comments,

                SalesmanSn = x.SlpCode,
                OwnerEmployeeSn = x.OwnerCode,

                Currency = x.DocCur,
                DocTotal = x.DocTotal.Value,
                DiscountPercent = x.DiscPrcnt.Value,
                VatPercent = x.VatPercent.Value,
                Vat = x.VatSum,
                TotalDiscountAndRounding = x.DiscSum,
                ToPay = x.DocTotal - x.PaidToDate,
                GrossProfit = x.GrosProfit,
                AttachmentsCode = x.AtcEntry
            };

        private static readonly Expression<Func<OINV, InvoiceEntity>> AsInvoiceHeaderEntity =
            x => new InvoiceEntity
            {
                Key = x.DocEntry,
                Sn = x.DocNum,
                ExternalSn = x.NumAtCard,
                CustomerSn = x.CardCode,
                CustomerName = x.CardName,
                CustomerAddress = x.Address,
                CustomerFederalTaxId = x.LicTradNum,

                IsClosed = x.DocStatus == "C",
                IsCanceled = x.CANCELED == "Y",

                Date = x.DocDate,
                CreationDateTime = x.CreateTS.HasValue && x.CreateDate.HasValue ? x.CreateDate.Value
                    .AddSeconds( x.CreateTS.Value % 100)
                    .AddMinutes(( x.CreateTS.Value / 100) % 100)
                    .AddHours(( x.CreateTS.Value / 10000) % 10000) : x.CreateDate,
                
                LastUpdateDateTime = x.UpdateTS.HasValue && x.UpdateDate.HasValue ? x.UpdateDate.Value
                    .AddSeconds( x.UpdateTS.Value % 100)
                    .AddMinutes(( x.UpdateTS.Value / 100) % 100)
                    .AddHours(( x.UpdateTS.Value / 10000) % 10000) : x.UpdateDate,
                ClosingDate = x.ClsDate,
                //SupplyDate = q.DocDueDate,

                Comments = x.Comments,

                SalesmanSn = x.SlpCode,
                OwnerEmployeeSn = x.OwnerCode,

                Currency = x.DocCur,
                DocTotal = x.DocTotal.Value,
                DiscountPercent = x.DiscPrcnt.Value,
                VatPercent = x.VatPercent.Value,
                Vat = x.VatSum,
                TotalDiscountAndRounding = x.DiscSum,
                ToPay = x.DocTotal - x.PaidToDate,
                GrossProfit = x.GrosProfit,
                AttachmentsCode = x.AtcEntry
            };

        private static readonly Expression<Func<ORIN, CreditNoteEntity>> AsCreditNoteHeaderEntity =
            x => new CreditNoteEntity
            {
                Key = x.DocEntry,
                Sn = x.DocNum,
                ExternalSn = x.NumAtCard,
                CustomerSn = x.CardCode,
                CustomerName = x.CardName,
                CustomerAddress = x.Address,
                CustomerFederalTaxId = x.LicTradNum,

                IsClosed = x.DocStatus == "C",
                IsCanceled = x.CANCELED == "Y",

                Date = x.DocDate,
                CreationDateTime = x.CreateTS.HasValue && x.CreateDate.HasValue ? x.CreateDate.Value
                    .AddSeconds( x.CreateTS.Value % 100)
                    .AddMinutes(( x.CreateTS.Value / 100) % 100)
                    .AddHours(( x.CreateTS.Value / 10000) % 10000) : x.CreateDate,
                
                LastUpdateDateTime = x.UpdateTS.HasValue && x.UpdateDate.HasValue ? x.UpdateDate.Value
                    .AddSeconds( x.UpdateTS.Value % 100)
                    .AddMinutes(( x.UpdateTS.Value / 100) % 100)
                    .AddHours(( x.UpdateTS.Value / 10000) % 10000) : x.UpdateDate,
                ClosingDate = x.ClsDate,
                // SupplyDate = q.DocDueDate,

                Comments = x.Comments,
                SalesmanSn = x.SlpCode,
                OwnerEmployeeSn = x.OwnerCode,

                Currency = x.DocCur,
                DocTotal = x.DocTotal.Value,
                DiscountPercent = x.DiscPrcnt.Value,
                VatPercent = x.VatPercent.Value,
                Vat = x.VatSum,
                TotalDiscountAndRounding = x.DiscSum,
                ToPay = x.DocTotal - x.PaidToDate,
                GrossProfit = x.GrosProfit,
                AttachmentsCode = x.AtcEntry
            };

        private static readonly Expression<Func<ODPI, DownPaymentRequest>> AsDownPaymentRequestHeader =
            q => new DownPaymentRequest
            {
                Key = q.DocEntry,
                Sn = q.DocNum,
                ExternalSn = q.NumAtCard,
                CustomerSn = q.CardCode,
                CustomerName = q.CardName,
                CustomerAddress = q.Address,
                CustomerFederalTaxId = q.LicTradNum,

                IsClosed = q.DocStatus == "C",
                IsCanceled = q.CANCELED == "Y",

                Date = q.DocDate,
                CreationDateTime = q.CreateTS.HasValue && q.CreateDate.HasValue
                    ? q.CreateDate.Value
                        .AddSeconds(q.CreateTS.Value % 100)
                        .AddMinutes((q.CreateTS.Value / 100) % 100)
                        .AddHours((q.CreateTS.Value / 10000) % 10000)
                    : q.CreateDate,

                LastUpdateDateTime = q.UpdateTS.HasValue && q.UpdateDate.HasValue
                    ? q.UpdateDate.Value
                        .AddSeconds(q.UpdateTS.Value % 100)
                        .AddMinutes((q.UpdateTS.Value / 100) % 100)
                        .AddHours((q.UpdateTS.Value / 10000) % 10000)
                    : q.UpdateDate,
                ClosingDate = q.ClsDate,
                // SupplyDate = q.DocDueDate,

                Comments = q.Comments,
                SalesmanSn = q.SlpCode,
                OwnerEmployeeSn = q.OwnerCode,

                Currency = q.DocCur,
                DocTotal = q.DocTotal.Value,
                DiscountPercent = q.DiscPrcnt.Value,
                VatPercent = q.VatPercent.Value,
                Vat = q.VatSum,
                TotalDiscountAndRounding = q.DiscSum,
                ToPay = q.DocTotal - q.PaidToDate,
                GrossProfit = q.GrosProfit,
                AttachmentsCode = q.AtcEntry
            };


        private static readonly Expression<Func<QUT1, DocItemEntity>> AsDocItemEntityQUT1 =
            i => new DocItemEntity
            {
                DocKey = i.DocEntry,
                ItemNumber = i.LineNum,
                Code = i.ItemCode,
                Description = i.Dscription,
                IsOpen = i.LineStatus == "O",
                Quantity = i.Quantity.Value,
                Currency = i.Currency,
                PricePerQuantity = i.DiscPrcnt.Value < 100 ? i.Price.Value / (1 - i.DiscPrcnt.Value / 100) : 0,
                DiscountPercent = i.DiscPrcnt.Value,
                Comments = i.FreeTxt,
                Details = i.Text,
                OpenQuantity = i.OpenQty.Value,
                VisualOrder = i.VisOrder.Value,
                BaseItemNumber = i.BaseLine,
                BaseDoc = i.BaseEntry.HasValue
                    ? new DocReferencedEntity
                    {
                        DocKey = i.BaseEntry.Value,
                        DocType = i.BaseType.Value == 13 ? DocType.Invoice :
                            i.BaseType.Value == 17 ? DocType.Order :
                            i.BaseType.Value == 23 ? DocType.Quotation :
                            i.BaseType.Value == 14 ? DocType.CreditNote :
                            i.BaseType.Value == 15 ? DocType.DeliveryNote :
                            i.BaseType.Value == 203 ? DocType.DownPaymentRequest :
                            i.BaseType.Value == 24 ? DocType.Receipt : DocType.Other
                    }
                    : null,
                FollowDoc = i.TrgetEntry.HasValue
                    ? new DocReferencedEntity
                    {
                        DocKey = i.TrgetEntry.Value,
                        DocType = i.TargetType.Value == 13 ? DocType.Invoice :
                            i.TargetType.Value == 17 ? DocType.Order :
                            i.TargetType.Value == 23 ? DocType.Quotation :
                            i.TargetType.Value == 14 ? DocType.CreditNote :
                            i.TargetType.Value == 15 ? DocType.DeliveryNote :
                            i.TargetType.Value == 203 ? DocType.DownPaymentRequest :
                            i.TargetType.Value == 24 ? DocType.Receipt : DocType.Other
                    }
                    : null
            };

        private static readonly Expression<Func<RDR1, DocItemEntity>> AsDocItemEntityRdr1 =
            i => new DocItemEntity
            {
                DocKey = i.DocEntry,
                ItemNumber = i.LineNum,
                Code = i.ItemCode,
                Description = i.Dscription,
                IsOpen = i.LineStatus == "O",
                Quantity = i.Quantity.Value,
                Currency = i.Currency,
                PricePerQuantity = i.DiscPrcnt.Value < 100 ? i.Price.Value / (1 - i.DiscPrcnt.Value / 100) : 0,
                DiscountPercent = i.DiscPrcnt.Value,
                Comments = i.FreeTxt,
                Details = i.Text,

                OpenQuantity = i.OpenQty.Value,
                VisualOrder = i.VisOrder.Value,
                BaseItemNumber = i.BaseLine,
                BaseDoc = i.BaseEntry.HasValue
                    ? new DocReferencedEntity
                    {
                        DocKey = i.BaseEntry.Value,
                        DocType = i.BaseType.Value == 13 ? DocType.Invoice :
                            i.BaseType.Value == 17 ? DocType.Order :
                            i.BaseType.Value == 23 ? DocType.Quotation :
                            i.BaseType.Value == 14 ? DocType.CreditNote :
                            i.BaseType.Value == 15 ? DocType.DeliveryNote :
                            i.BaseType.Value == 203 ? DocType.DownPaymentRequest :
                            i.BaseType.Value == 24 ? DocType.Receipt : DocType.Other
                    }
                    : null,
                FollowDoc = i.TrgetEntry.HasValue
                    ? new DocReferencedEntity
                    {
                        DocKey = i.TrgetEntry.Value,
                        DocType = i.TargetType.Value == 13 ? DocType.Invoice :
                            i.TargetType.Value == 17 ? DocType.Order :
                            i.TargetType.Value == 23 ? DocType.Quotation :
                            i.TargetType.Value == 14 ? DocType.CreditNote :
                            i.TargetType.Value == 15 ? DocType.DeliveryNote :
                            i.TargetType.Value == 203 ? DocType.DownPaymentRequest :
                            i.TargetType.Value == 24 ? DocType.Receipt : DocType.Other
                    }
                    : null
            };

        private static readonly Expression<Func<DLN1, DocItemEntity>> AsDocItemEntityDLN1 =
            i => new DocItemEntity
            {
                DocKey = i.DocEntry,
                ItemNumber = i.LineNum,
                Code = i.ItemCode,
                Description = i.Dscription,
                IsOpen = i.LineStatus == "O",
                Quantity = i.Quantity.Value,
                Currency = i.Currency,
                PricePerQuantity = i.DiscPrcnt.Value < 100 ? i.Price.Value / (1 - i.DiscPrcnt.Value / 100) : 0,
                DiscountPercent = i.DiscPrcnt.Value,
                Comments = i.FreeTxt,
                Details = i.Text,

                OpenQuantity = i.OpenQty.Value,
                VisualOrder = i.VisOrder.Value,
                BaseItemNumber = i.BaseLine,
                BaseDoc = i.BaseEntry.HasValue
                    ? new DocReferencedEntity
                    {
                        DocKey = i.BaseEntry.Value,
                        DocType = i.BaseType.Value == 13 ? DocType.Invoice :
                            i.BaseType.Value == 17 ? DocType.Order :
                            i.BaseType.Value == 23 ? DocType.Quotation :
                            i.BaseType.Value == 14 ? DocType.CreditNote :
                            i.BaseType.Value == 15 ? DocType.DeliveryNote :
                            i.BaseType.Value == 203 ? DocType.DownPaymentRequest :
                            i.BaseType.Value == 24 ? DocType.Receipt : DocType.Other
                    }
                    : null,
                FollowDoc = i.TrgetEntry.HasValue
                    ? new DocReferencedEntity
                    {
                        DocKey = i.TrgetEntry.Value,
                        DocType = i.TargetType.Value == 13 ? DocType.Invoice :
                            i.TargetType.Value == 17 ? DocType.Order :
                            i.TargetType.Value == 23 ? DocType.Quotation :
                            i.TargetType.Value == 14 ? DocType.CreditNote :
                            i.TargetType.Value == 15 ? DocType.DeliveryNote :
                            i.TargetType.Value == 203 ? DocType.DownPaymentRequest :
                            i.TargetType.Value == 24 ? DocType.Receipt : DocType.Other
                    }
                    : null
            };

        private static readonly Expression<Func<INV1, DocItemEntity>> AsDocItemEntityInv1 =
            i => new DocItemEntity
            {
                DocKey = i.DocEntry,
                ItemNumber = i.LineNum,
                Code = i.ItemCode,
                Description = i.Dscription,
                IsOpen = i.LineStatus == "O",
                Quantity = i.Quantity.Value,
                Currency = i.Currency,
                PricePerQuantity = i.DiscPrcnt.Value < 100 ? i.Price.Value / (1 - i.DiscPrcnt.Value / 100) : 0,
                DiscountPercent = i.DiscPrcnt.Value,
                Comments = i.FreeTxt,
                Details = i.Text,

                OpenQuantity = i.OpenQty.Value,
                VisualOrder = i.VisOrder.Value,
                BaseItemNumber = i.BaseLine,
                BaseDoc = i.BaseEntry.HasValue
                    ? new DocReferencedEntity
                    {
                        DocKey = i.BaseEntry.Value, //TODO - BaseRafe may be null but BasseEntry always not null 
                        DocType = i.BaseType.Value == 13 ? DocType.Invoice :
                            i.BaseType.Value == 17 ? DocType.Order :
                            i.BaseType.Value == 23 ? DocType.Quotation :
                            i.BaseType.Value == 14 ? DocType.CreditNote :
                            i.BaseType.Value == 15 ? DocType.DeliveryNote :
                            i.BaseType.Value == 203 ? DocType.DownPaymentRequest :
                            i.BaseType.Value == 24 ? DocType.Receipt : DocType.Other
                    }
                    : null,
                FollowDoc = i.TrgetEntry.HasValue
                    ? new DocReferencedEntity
                    {
                        DocKey = i.TrgetEntry.Value,
                        DocType = i.TargetType.Value == 13 ? DocType.Invoice :
                            i.TargetType.Value == 17 ? DocType.Order :
                            i.TargetType.Value == 23 ? DocType.Quotation :
                            i.TargetType.Value == 14 ? DocType.CreditNote :
                            i.TargetType.Value == 15 ? DocType.DeliveryNote :
                            i.TargetType.Value == 203 ? DocType.DownPaymentRequest :
                            i.TargetType.Value == 24 ? DocType.Receipt : DocType.Other
                    }
                    : null
            };

        private static readonly Expression<Func<RIN1, DocItemEntity>> AsDocItemEntityRin1 =
            i => new DocItemEntity
            {
                DocKey = i.DocEntry,
                ItemNumber = i.LineNum,
                Code = i.ItemCode,
                Description = i.Dscription,
                IsOpen = i.LineStatus == "O",
                Quantity = i.Quantity.Value,
                Currency = i.Currency,
                PricePerQuantity = i.DiscPrcnt.Value < 100 ? i.Price.Value / (1 - i.DiscPrcnt.Value / 100) : 0,
                DiscountPercent = i.DiscPrcnt.Value,
                Comments = i.FreeTxt,
                Details = i.Text,
                OpenQuantity = i.OpenQty.Value,
                VisualOrder = i.VisOrder.Value,
                BaseItemNumber = i.BaseLine,
                BaseDoc = i.BaseEntry.HasValue
                    ? new DocReferencedEntity
                    {
                        DocKey = i.BaseEntry.Value,
                        DocType = i.BaseType.Value == 13 ? DocType.Invoice :
                            i.BaseType.Value == 17 ? DocType.Order :
                            i.BaseType.Value == 23 ? DocType.Quotation :
                            i.BaseType.Value == 14 ? DocType.CreditNote :
                            i.BaseType.Value == 15 ? DocType.DeliveryNote :
                            i.BaseType.Value == 203 ? DocType.DownPaymentRequest :
                            i.BaseType.Value == 24 ? DocType.Receipt : DocType.Other
                    }
                    : null,
                FollowDoc = i.TrgetEntry.HasValue
                    ? new DocReferencedEntity
                    {
                        DocKey = i.TrgetEntry.Value,
                        DocType = i.TargetType.Value == 13 ? DocType.Invoice :
                            i.TargetType.Value == 17 ? DocType.Order :
                            i.TargetType.Value == 23 ? DocType.Quotation :
                            i.TargetType.Value == 14 ? DocType.CreditNote :
                            i.TargetType.Value == 15 ? DocType.DeliveryNote :
                            i.TargetType.Value == 203 ? DocType.DownPaymentRequest :
                            i.TargetType.Value == 24 ? DocType.Receipt : DocType.Other
                    }
                    : null
            };

        private static readonly Expression<Func<DPI1, DocItemEntity>> AsDocItemEntityDpi1 =
            i => new DocItemEntity
            {
                DocKey = i.DocEntry,
                ItemNumber = i.LineNum,
                Code = i.ItemCode,
                Description = i.Dscription,
                IsOpen = i.LineStatus == "O",
                Quantity = i.Quantity.Value,
                Currency = i.Currency,
                PricePerQuantity = i.DiscPrcnt.Value < 100 ? i.Price.Value / (1 - i.DiscPrcnt.Value / 100) : 0,
                DiscountPercent = i.DiscPrcnt.Value,
                Comments = i.FreeTxt,
                Details = i.Text,

                OpenQuantity = i.OpenQty.Value,
                VisualOrder = i.VisOrder.Value,
                BaseItemNumber = i.BaseLine,
                BaseDoc = i.BaseEntry.HasValue
                    ? new DocReferencedEntity
                    {
                        DocKey = i.BaseEntry.Value,
                        DocType = i.BaseType.Value == 13 ? DocType.Invoice :
                            i.BaseType.Value == 17 ? DocType.Order :
                            i.BaseType.Value == 23 ? DocType.Quotation :
                            i.BaseType.Value == 14 ? DocType.CreditNote :
                            i.BaseType.Value == 15 ? DocType.DeliveryNote :
                            i.BaseType.Value == 203 ? DocType.DownPaymentRequest :
                            i.BaseType.Value == 24 ? DocType.Receipt : DocType.Other
                    }
                    : null,
                FollowDoc = i.TrgetEntry.HasValue
                    ? new DocReferencedEntity
                    {
                        DocKey = i.TrgetEntry.Value,
                        DocType = i.TargetType.Value == 13 ? DocType.Invoice :
                            i.TargetType.Value == 17 ? DocType.Order :
                            i.TargetType.Value == 23 ? DocType.Quotation :
                            i.TargetType.Value == 14 ? DocType.CreditNote :
                            i.TargetType.Value == 15 ? DocType.DeliveryNote :
                            i.TargetType.Value == 203 ? DocType.DownPaymentRequest :
                            i.TargetType.Value == 24 ? DocType.Receipt : DocType.Other
                    }
                    : null
            };
    }
}