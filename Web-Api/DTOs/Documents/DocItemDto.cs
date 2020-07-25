using DataAccessLayer.Entities.Documents;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Entities.Documents.Items;

namespace Web_Api.DTOs.Documents
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class DocItemDto 
    {
        public long DocKey { get; set; }
        public int? ItemNumber { get; set; }
        public int VisualOrder { get; set; }

        public string Code { get; set; }
        public bool IsOpen { get; set; }
        public string Description { get; set; }

        //Properties like width length height u_roll etc...
        public Dictionary<string, object> Properties { get; set; }

        public decimal Quantity { get; set; }
        public decimal OpenQuantity { get; set; }

        public string Currency { get; set; }
        public decimal PricePerQuantity { get; set; }
     
        public decimal DiscountPercent { get; set; }

        public string Comments { get; set; }
        public string Details { get; set; }


        public DocReferenceDto BaseDoc { get; set; }
        public int? BaseItemNumber { get; set; }
        public DocReferenceDto FollowDoc { get; set; }



        public class DocReferenceDto
        {
            public long DocKey { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public DocType DocType { get; set; }

        }
        public enum DocType { Invoice, Order, Quotation, CreditNote, DeliveryNote, DepositNote, Receipt, Other }
    }
}
