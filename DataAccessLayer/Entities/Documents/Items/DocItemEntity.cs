using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DataAccessLayer.Entities.Documents.Items
{
    public class DocItemEntity
    {
        public long DocKey { get; set; }
        public int? ItemNumber { get; set; }//null before creation
        public int VisualOrder { get; set; }
        public string Code { get; set; }
        public bool IsOpen { get; set; }
        public string Description { get; set; }

        //Properties like width length height u_roll etc...
        public Dictionary<string, object> Properties { get; set; }

        [Column(TypeName = "decimal(10,3)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal OpenQuantity { get; set; }

        public string Currency { get; set; }

        [Column(TypeName = "decimal(10,3)")]
        public decimal PricePerQuantity { get; set; }
        [NotMapped]

        public decimal Price => PricePerQuantity * Quantity;

        [Column(TypeName = "decimal(3,2)")]
        public decimal DiscountPercent { get; set; }
        [NotMapped]
        public decimal TotalDiscount => Price * (DiscountPercent / 100);

        [NotMapped]
        public decimal TotalPrice => Price - TotalDiscount;

        public string Comments { get; set; }
        public string Details { get; set; }

        public DocReferencedEntity BaseDoc { get; set; }
        public int? BaseItemNumber { get; set; }
        public DocReferencedEntity FollowDoc { get; set; }





    }
}
