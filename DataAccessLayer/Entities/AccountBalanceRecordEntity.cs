using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class AccountBalanceRecordEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? SN { get; set; }

        public enum DocumentTypes
        {
            Invoice,
            Receipt,
            CreditInvoice,
            Journal,
            Other
        }

        public string OwnerSn { get; set; }
        public string Doc1Sn { get; set; }
        public string Doc2Sn { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(10,3)")] public decimal Debt { get; set; }
        [Column(TypeName = "decimal(10,3)")] public decimal BalanceDebt { get; set; }
        public string Currency { get; set; }
        public string Memo { get; set; }
        public DocumentTypes Type { get; set; }
    }
}