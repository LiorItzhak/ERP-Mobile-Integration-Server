using CrossLayersUtils.Aspects;
using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Repositories;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CrossLayersUtils;
using DataAccessLayer.Entities.Documents.Headers;
using DataAccessLayer.Entities.Documents.Items;
using DataAccessLayer.Repositories.Impls.SAP;
using SAPbouiCOM;
using static DataAccessLayer.SAPHandler.DiApiHandler.SapDiApiContext;
using ICompany = SAPbobsCOM.ICompany;

namespace DataAccessLayer.SAPHandler.DiApiHandler.SapDbSets
{
    interface IDocumentDiSet<TDocument>: IDiSet<TDocument> where TDocument : DocumentHeaderEntity, IDocumentEntity
    {
        TDocument Close(int docEntry);
        TDocument Cancel(int docEntry);

        void CreatePdf(int docEntry);
    }
    public class DocumentDiSet<TDocument> : DiSet<TDocument,int>, IDocumentDiSet<TDocument> where TDocument : DocumentHeaderEntity, IDocumentEntity, new()
    {
        private readonly CompanyContext _companyContext;
        private readonly IProductPropertiesRepository _propertiesRepository;
        private readonly Type _curDocType = typeof(TDocument);
        private readonly Type _quotationType = typeof(QuotationEntity);
        private readonly Type _orderType = typeof(OrderEntity);
        private readonly Type _deliveryNoteType = typeof(DeliveryNoteEntity);
        private readonly Type _invoiceType = typeof(InvoiceEntity);
        private readonly Type _creditNoteType = typeof(CreditNoteEntity);


        public DocumentDiSet(CompanyContext context) : base(context)
        {
            _companyContext = context;
            _propertiesRepository = new DemoProductPropertiesRepository();
        }



        [LogMethod]
        public override TDocument Add(TDocument entity)
        {
            ValidateDocumentEntityBeforeCreateNew(entity);
            var company = _companyContext.ConnectCompany();
            var document = MapToSapDocument(GetSapDocument(company), entity);
            var err = document.Add();
            if (err != 0)
                throw new Exception($"Can't add the document,SAP DI-API error code {err} \n {company.GetLastErrorDescription()}");
            var docEntry = Convert.ToInt32(company.GetNewObjectKey());
            document.GetByKey(docEntry);
            Debug.WriteLine($"Added new Document with SN = {document.DocNum} , docType = \n");
            return MapToEntity(document);

        }

        public override TDocument Update(TDocument entity)
        {
            if (!entity.Key.HasValue)
                throw new IllegalArgumentException("Cant update a document with null Key", entity.GetType().FullName);

            var company = _companyContext.ConnectCompany();
            var document = GetSapDocument(company);

            if (!document.GetByKey(entity.Key.Value))
                throw new Exception($"SAP-DI-API - Document don't exist : DocEntry = {entity.Key}");
            document = MapToSapDocument(document, entity);
            var err = document.Update();
            if (err != 0)
                throw new Exception($"Can't update the document,SAP DI-API error code {err} \n {company.GetLastErrorDescription()} ");
            document.GetByKey(document.DocEntry);
            Debug.WriteLine($"Updated  Document with SN = {document.DocNum}\n");
            return MapToEntity(document);

        }

        public override void Remove(int id)
        {
            throw new NotImplementedException();
        }


        [LogMethod]
        public  TDocument Close(int docEntry)
        {
            var company = _companyContext.ConnectCompany();
            var document = GetSapDocument(company);

            if (!document.GetByKey(docEntry))
                throw new Exception($"SAP-DI-API - Document don't exist : DocEntry = {docEntry}");
            var docNum = document.DocNum;
            var err = document.Close();
            if (err != 0)
                throw new Exception($"Can't close the document,SAP DI-API error code {err} \n {company.GetLastErrorDescription()}");
            Debug.WriteLine($"Closed! document with SN = {docNum}\n");
            var result = MapToEntity(document);
            result.IsClosed = true;
            result.ClosingDate = DateTime.Now;
            return result;
        }

        [LogMethod]
        public   TDocument Cancel(int docEntry)
        {
            var company = _companyContext.ConnectCompany();
            var document = GetSapDocument(company);

            if (!document.GetByKey(docEntry))
                throw new Exception($"SAP-DI-API - document don't exist : DocEntry = {docEntry}");
            var docNum = document.DocNum;
            var err = document.Cancel();
            if (err != 0)
                throw new Exception($"Can't Cancel the document,SAP DI-API error code {err} \n {company.GetLastErrorDescription()}");
            Debug.WriteLine($"Canceled! document with SN = {docNum}\n");
            var result = MapToEntity(document);
            result.IsCanceled = true;
            result.IsClosed = true;
            result.ClosingDate = DateTime.Now;
            return result;

        }

        public void CreatePdf(int docEntry)
        {

            


//            CompanyService oCmpSrv;
//            ReportLayoutsService oReportLayoutService;
//            ReportLayoutPrintParams oPrintParam;
//            oCmpSrv = _companyContext.ConnectCompany().GetCompanyService();
//            oReportLayoutService = (ReportLayoutsService)oCmpSrv.GetBusinessService(SAPbobsCOM.ServiceTypes.ReportLayoutsService);
//            oPrintParam = (ReportLayoutPrintParams)oReportLayoutService.GetDataInterface(SAPbobsCOM.ReportLayoutsServiceDataInterfaces.rlsdiReportLayoutPrintParams);
//            oPrintParam.LayoutCode = "INV20014";
//            oPrintParam.DocEntry = 350;
//            oReportLayoutService.Print(oPrintParam);

//            var oCmpSrv = _companyContext.ConnectCompany().getA
//                .GetCompanyService();

        }


        private Documents GetSapDocument(ICompany company, Type docType = null)
        {
             docType = docType != null ? docType : _curDocType;
            if (docType == _quotationType)
                return (Documents)company.GetBusinessObject(BoObjectTypes.oQuotations);
            if (docType == _orderType)
                return (Documents)company.GetBusinessObject(BoObjectTypes.oOrders);
            if (docType == _invoiceType)
                return (Documents)company.GetBusinessObject(BoObjectTypes.oInvoices);
            if (docType == _deliveryNoteType)
                return (Documents)company.GetBusinessObject(BoObjectTypes.oDeliveryNotes);
            if (docType == _creditNoteType)
                return (Documents)company.GetBusinessObject(BoObjectTypes.oCreditNotes);
            return null;

        }
        private static void ValidateDocumentEntityBeforeCreateNew(TDocument document)
        {
            if (document.Sn.HasValue)
                throw new IllegalArgumentException("Cant create new document with non null SN", document.GetType().FullName);

            if (document.DocTotal.HasValue)
                throw new IllegalArgumentException("Cant create new document with non null DocTotal", document.GetType().FullName);

            if (document.TotalDiscountAndRounding.HasValue)
                throw new IllegalArgumentException("Cant create new document with non null TotalDiscountAndRounding", document.GetType().FullName);

            if (document.Vat.HasValue)
                throw new IllegalArgumentException("Cant create new document with non null VAT", document.GetType().FullName);

            if (document.CreationDateTime.HasValue)
                throw new IllegalArgumentException("Cant create new document with non null CreationDate", document.GetType().FullName);
        }



        private Documents MapToSapDocument(Documents sapDocument, TDocument document)
        {

            if (document.ExternalSn != null)
                sapDocument.NumAtCard = document.ExternalSn;
            if (document.CustomerSn != null)
                sapDocument.CardCode = document.CustomerSn;
            if (document.CustomerName != null)
                sapDocument.CardName = document.CustomerName;
            if (document.CustomerAddress != null)
                sapDocument.Address = document.CustomerAddress;
            if (document.CustomerFederalTaxId != null)
                sapDocument.FederalTaxID = document.CustomerFederalTaxId;

            if (document.Date != null)
                sapDocument.DocDate = document.Date.Value;
            if (document.ClosingDate != null)
                sapDocument.ClosingDate = document.ClosingDate.Value;

            if (_curDocType == _quotationType && (document as QuotationEntity).ValidUntil != null)
                sapDocument.DocDueDate = (document as QuotationEntity).ValidUntil.Value;
            else if (_curDocType == _orderType && (document as OrderEntity).SupplyDate != null)
                sapDocument.DocDueDate = (document as OrderEntity).SupplyDate.Value;
            else if (_curDocType == _deliveryNoteType && (document as DeliveryNoteEntity).SupplyDate != null)
                sapDocument.DocDueDate = (document as DeliveryNoteEntity).SupplyDate.Value;

            if (document.Comments != null)
                sapDocument.Comments = document.Comments;
            if (document.SalesmanSn != null)
                sapDocument.SalesPersonCode = document.SalesmanSn.Value;
            if (document.OwnerEmployeeSn != null)
                sapDocument.DocumentsOwner = document.OwnerEmployeeSn.Value;


            if (document.Currency != null)
                sapDocument.DocCurrency = document.Currency;

            sapDocument.DiscountPercent = Convert.ToDouble(document.DiscountPercent);
            if (document.VatPercent != null)
                sapDocument.VatPercent = Convert.ToDouble(document.VatPercent);

            if (document.AttachmentsCode.HasValue)
                sapDocument.AttachmentEntry = document.AttachmentsCode.Value;

            if (document.Items == null) return sapDocument;
           
            var newAdd = 0;
            foreach (var item in document.Items)
            {
                if (item.ItemNumber.HasValue)
                {
                    for(var i=0;i< sapDocument.Lines.Count+1;i++)//+1 throw exception if not found
                    {
                        sapDocument.Lines.SetCurrentLine(i);
                        if (sapDocument.Lines.LineNum == item.ItemNumber)
                            break;
                    }
                    if (item.Quantity > 0)
                        MapToDocLine(sapDocument.Lines, item);//update existing line
                    else
                        sapDocument.Lines.Delete();//delete existing line
                        
                }
                else
                {
                    //new document is initializing with one empty line
                    if(sapDocument.DocEntry == 0){
                        //new document
                        if(newAdd++ > 0)
                            sapDocument.Lines.Add();//add new line
                    }
                    else
                    {
                        //update document
                        sapDocument.Lines.Add();//add new line
                        sapDocument.Lines.SetCurrentLine(sapDocument.Lines.Count - 1);

                    }
                        
                    MapToDocLine(sapDocument.Lines, item);
                }
            }
            return sapDocument;
        }

        private Document_Lines MapToDocLine(Document_Lines docLine, DocItemEntity docItem)
        {
            docLine.ItemCode = docItem.Code;
            docLine.ItemDescription = docItem.Description;


            if (docItem.BaseItemNumber.HasValue)
            {
                docLine.BaseLine = docItem.BaseItemNumber.Value;

                docLine.BaseType = docItem.BaseDoc.DocType == DocType.Invoice ? 13 :
                      docItem.BaseDoc.DocType == DocType.Order ? 17 :
                      docItem.BaseDoc.DocType == DocType.Quotation ? 23 :
                      docItem.BaseDoc.DocType == DocType.CreditNote ? 14 :
                      docItem.BaseDoc.DocType == DocType.DeliveryNote ? 15 :
                      docItem.BaseDoc.DocType == DocType.DownPaymentRequest ? 203 :
                      docItem.BaseDoc.DocType == DocType.Receipt ? 24 : -1;
                docLine.BaseEntry = (int)docItem.BaseDoc.DocKey; 
            }


            docLine.FreeText = docItem.Comments;
            docLine.ItemDetails = docItem.Details;

            //  docLine.LineStatus = docItem.IsOpen? BoStatus.
            docLine.Quantity = Convert.ToDouble(docItem.Quantity);
            docLine.Currency = docItem.Currency;

            docLine.UnitPrice = Convert.ToDouble(docItem.PricePerQuantity);
            docLine.DiscountPercent = Convert.ToDouble(docItem.DiscountPercent);
            //docLine.LineTotal = Convert.ToDouble(docItem.TotalPrice);

            ///TODO handle default properties ///
            var pDic = _propertiesRepository.FindProperties(docItem.Code);
            pDic = pDic.ToDictionary(p => p.Key.ToLower(), p => p.Value);

            var defaultProperties = new List<string>();
            if (pDic.TryGetValue("width1", out var propertyKey))
            {
                defaultProperties.Add(propertyKey);
                if (docItem.Properties.ContainsKey(propertyKey))
                    docLine.Width1 = Convert.ToDouble(docItem.Properties[propertyKey]);
                else
                    docLine.Width1 = 1;//default value
            };
            if (pDic.TryGetValue("height1", out propertyKey))
            {
                defaultProperties.Add(propertyKey);
                if (docItem.Properties.ContainsKey(propertyKey))
                    docLine.Height1 = Convert.ToDouble(docItem.Properties[propertyKey]);
                else
                    docLine.Height1 = 1;//default value

            };
            if (pDic.TryGetValue("length1", out propertyKey))
            {
                defaultProperties.Add(propertyKey);
                if (docItem.Properties.ContainsKey(propertyKey))
                    docLine.Lengh1 = Convert.ToDouble(docItem.Properties[propertyKey]);
                else
                    docLine.Lengh1 = 1;//default value

            };

            var otherProperties = docItem.Properties.Where(p => !defaultProperties.Contains(p.Key.ToLower()))
                .ToDictionary(p => p.Key, p => p.Value);

            var sapProperties = _propertiesRepository.FindProperties(docItem.Code).ToDictionary(p => p.Value, p => p.Key);
            foreach (var key in otherProperties.Keys)
            {
                switch (docLine.UserFields.Fields.Item(sapProperties[key]).Type)
                {
                    case BoFieldTypes.db_Numeric:
                        docLine.UserFields.Fields.Item(sapProperties[key]).Value = Convert.ToInt32(otherProperties[key]);
                        break;
                    case BoFieldTypes.db_Float:
                        docLine.UserFields.Fields.Item(sapProperties[key]).Value = Convert.ToDecimal(otherProperties[key]);
                        break;
                    case BoFieldTypes.db_Date:
                        docLine.UserFields.Fields.Item(sapProperties[key]).Value = Convert.ToDateTime(otherProperties[key]);
                        break;
                    case BoFieldTypes.db_Alpha:
                        docLine.UserFields.Fields.Item(sapProperties[key]).Value = Convert.ToString(otherProperties[key]);
                        break;
                    case BoFieldTypes.db_Memo:
                        docLine.UserFields.Fields.Item(sapProperties[key]).Value = Convert.ToString(otherProperties[key]);
                        break;
                };

            }


            return docLine;
        }


        private TDocument MapToEntity(IDocuments sapDoc)
        {
            var document = new TDocument
            {
                Key =  sapDoc.DocEntry,
                Sn = sapDoc.DocNum,
                ExternalSn = sapDoc.NumAtCard,
                CustomerSn = sapDoc.CardCode,
                CustomerName = sapDoc.CardName,
                CustomerAddress = sapDoc.Address,
                CustomerFederalTaxId = sapDoc.FederalTaxID,

                IsClosed = sapDoc.ClosingDate > sapDoc.CreationDate,
                IsCanceled = sapDoc.Cancelled == BoYesNoEnum.tYES,

                Date = sapDoc.DocDate,
                CreationDateTime = sapDoc.CreationDate,
                ClosingDate = sapDoc.ClosingDate,
                

                Comments = sapDoc.Comments,

                SalesmanSn = sapDoc.SalesPersonCode,
                OwnerEmployeeSn = sapDoc.DocumentsOwner,

                Currency = sapDoc.DocCurrency,
                DocTotal = Convert.ToDecimal(sapDoc.DocTotal),
                DiscountPercent = Convert.ToDecimal(sapDoc.DiscountPercent),
                VatPercent = Convert.ToDecimal(sapDoc.VatPercent),
                Vat = Convert.ToDecimal(sapDoc.VatSum),
                TotalDiscountAndRounding = Convert.ToDecimal(sapDoc.TotalDiscount),
                AttachmentsCode = sapDoc.AttachmentEntry
   
            };

            if (_curDocType == _quotationType)
                (document as QuotationEntity).ValidUntil = sapDoc.DocDueDate;
            else if (_curDocType == _orderType)
                (document as OrderEntity).SupplyDate = sapDoc.DocDueDate;
            else if (_curDocType == _deliveryNoteType)
                (document as DeliveryNoteEntity).SupplyDate = sapDoc.DocDueDate;

            //add items
            document.Items = new List<DocItemEntity>();
            for (var itemNumber = 0; itemNumber < sapDoc.Lines.Count; itemNumber++)
            {
                sapDoc.Lines.SetCurrentLine(itemNumber);

                var i = sapDoc.Lines;
                var docItem = new DocItemEntity
                {
                    ItemNumber = i.LineNum,
                    Code = i.ItemCode,
                    Description = i.ItemDescription,
                    IsOpen = i.LineStatus == BoStatus.bost_Open,
                    Quantity = Convert.ToDecimal(i.Quantity),
                    Currency = i.Currency,
                    PricePerQuantity = Convert.ToDecimal(i.UnitPrice),
                    DiscountPercent = Convert.ToDecimal(i.DiscountPercent),
                    Comments = i.FreeText,
                    Details = i.Text,
                    VisualOrder = i.VisualOrder,
                    OpenQuantity = Convert.ToDecimal(i.RemainingOpenQuantity)
                 
                };

                var pDic = _propertiesRepository.FindProperties(docItem.Code);
                pDic = pDic.ToDictionary(p => p.Key.ToLower(), p => p.Value);

                docItem.Properties = new Dictionary<string, object>();
                var defaultProperties = new List<string>();
                if (pDic.TryGetValue("width1", out var propertyKey))
                {
                    defaultProperties.Add(propertyKey);
                    docItem.Properties.Add(propertyKey, Convert.ToDouble(i.Width1));
                };
                if (pDic.TryGetValue("height1", out propertyKey))
                {
                    defaultProperties.Add(propertyKey);
                    docItem.Properties.Add(propertyKey, Convert.ToDouble(i.Height1));
                };
                if (pDic.TryGetValue("length1", out propertyKey))
                {
                    defaultProperties.Add(propertyKey);
                    docItem.Properties.Add(propertyKey, Convert.ToDouble(i.Lengh1));
                };

                var otherProperties = _propertiesRepository.FindProperties(docItem.Code).Where(p => !defaultProperties.Contains(p.Value.ToLower()))
                    .ToDictionary(p => p.Value, p => p.Key);

                var sapProperties = _propertiesRepository.FindProperties(docItem.Code).ToDictionary(p => p.Value, p => p.Key);

                foreach (var key in otherProperties.Keys)
                {
                    switch (i.UserFields.Fields.Item(sapProperties[key]).Type)
                    {
                        case BoFieldTypes.db_Numeric:
                            docItem.Properties.Add(key, Convert.ToInt32(i.UserFields.Fields.Item(sapProperties[key]).Value));
                            break;
                        case BoFieldTypes.db_Float:
                            docItem.Properties.Add(key, Convert.ToDecimal(i.UserFields.Fields.Item(sapProperties[key]).Value));
                            break;
                        case BoFieldTypes.db_Date:
                            docItem.Properties.Add(key, Convert.ToDateTime(i.UserFields.Fields.Item(sapProperties[key]).Value));
                            break;
                        case BoFieldTypes.db_Alpha:
                            docItem.Properties.Add(key, Convert.ToString(i.UserFields.Fields.Item(sapProperties[key]).Value));
                            break;
                        case BoFieldTypes.db_Memo:
                            docItem.Properties.Add(key, Convert.ToString(i.UserFields.Fields.Item(sapProperties[key]).Value));
                            break;
                    };

                }


                if (i.BaseType != -1)
                {
                    docItem.BaseDoc = new DocReferencedEntity();

                    docItem.BaseItemNumber = i.BaseLine;

                    // i.BaseType == 203 ?  typeof() :
                    //   i.BaseType == 24 ? ?typeof(OrderEntity) :? typeof(OrderEntity);


                    docItem.BaseDoc.DocType = i.BaseType == 13 ? DocType.Invoice :
                    i.BaseType == 17 ? DocType.Order :
                    i.BaseType == 23 ? DocType.Quotation :
                    i.BaseType == 14 ? DocType.CreditNote :
                    i.BaseType == 15 ? DocType.DeliveryNote :
                    i.BaseType == 203 ? DocType.DownPaymentRequest :
                    i.BaseType == 24 ? DocType.Receipt : DocType.Other;
                    docItem.BaseDoc.DocKey = i.BaseEntry;
                }

                document.Items.Add(docItem);
            }

            return document;
        }

    }
}
