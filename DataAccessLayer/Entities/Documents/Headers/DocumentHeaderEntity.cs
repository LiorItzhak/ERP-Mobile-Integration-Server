using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities.Documents.Headers
{
    public abstract class DocumentHeaderEntity
    {
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int? Key { get;  set; }

        public int? Sn { get;  set; }
        public string ExternalSn { get; set; }

        public string CustomerSn { get; set; }
        public string CustomerName { get; set; }
        public string CustomerFederalTaxId { get; set; }
        public string CustomerAddress { get; set; }


        public bool? IsClosed { get;  set; }
        public bool? IsCanceled { get;  set; }

        public DateTime? Date { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
        public DateTime? ClosingDate { get; set; }

        public string Comments { get; set; }
        public int? SalesmanSn { get; set; }
        public int? OwnerEmployeeSn { get; set; }
        
        public string Currency { get; set; }
        
        [Column(TypeName = "decimal(3,2)")]
        public decimal? DiscountPercent { get; set; }
        [Column(TypeName = "decimal(3,2)")]
        public decimal? VatPercent { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal? DocTotal { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal? TotalDiscountAndRounding { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal? ToPay { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal? GrossProfit { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal? Vat { get; set; }

    }
}
