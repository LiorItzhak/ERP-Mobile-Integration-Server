using System.Collections.Generic;

// ReSharper disable ClassNeverInstantiated.Global
namespace Web_Api.DTOs.Documents
{
    public abstract class DocumentDto
    {
        public int? Key { get;  set; }
        public int? Sn { get; set; }
        public string ExternalSn { get; set; }

        public string CustomerSn { get; set; }
        public string CustomerName { get; set; }
        public string CustomerFederalTaxId { get; set; }
        public string CustomerAddress { get; set; }


        public bool? IsClosed { get; set; }
        public bool? IsCanceled { get; set; }

        public string Date { get; set; }
        public string CreationDateTime { get; set; }
        public string LastUpdateDateTime { get; set; }
        public string ClosingDate { get; set; }

        public string Comments { get; set; }
        public int? SalesmanSn { get; set; }
        public int? OwnerEmployeeSn { get; set; }
        public string Currency { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? VatPercent { get; set; }
        public decimal? DocTotal { get; set; }
        public decimal? TotalDiscountAndRounding { get; set; }
        public decimal? Vat { get; set; }

        public decimal? ToPay { get; set; }
        public decimal? GrossProfit { get; set; }

        public List<DocItemDto> Items { get; set; }

    }
    
    
    public class InvoiceDto : DocumentDto { }

    public class OrderDto : DocumentDto
    {
        public string SupplyDate { get; set; }
    }
    
    public class QuotationDto : DocumentDto
    {
        public string ValidUntil { get; set; }
    }
    
    public class DeliveryNoteDto : DocumentDto
    {
        public string SupplyDate { get; set; }

    }
    
    public class CreditNoteDto : DocumentDto
    {
    }
    
    
    public class DownPaymentRequestDto: DocumentDto { }
}
