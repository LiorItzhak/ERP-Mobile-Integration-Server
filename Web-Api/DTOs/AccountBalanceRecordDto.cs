using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api.DTOs
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class AccountBalanceRecordDto
    {
        public enum DocumentTypes { Invoice, Receipt, CreditInvoice, Journal, Other }
        public int? Sn { get; set; }
        public string OwnerSn { get; set; }
        public string Doc1Sn { get; set; }
        public string Doc2Sn { get; set; }
        public string Date { get; set; }
        public decimal Debt { get; set; }
        public decimal BalanceDebt { get; set; }
        public string Currency { get; set; }
        public string Memo { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentTypes Type { get; set; }

      
    }
}
