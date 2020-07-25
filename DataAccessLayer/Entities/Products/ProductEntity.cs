using DataAccessLayer.Entities.Products.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities.Products
{
    public class ProductEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Code { get; set; }
        public int GroupCode { get; set; }
        public string Name { get; set; }
        public string NameForeign { get; set; }
        public string Barcode { get; set; }
        public string PictureUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsForSell { get; set; }
        public bool IsForBuy { get; set; }
        public List<ProductPropertyEntity> Properties { get; set; }
        public string AutoQuantityCalculationExpression { get; set; }
        public DateTime? CreationDateTime{ get; set; }
        public DateTime? LastUpdateDateTime { get; set; }

        public Dictionary<string,decimal> SellPriceList { get; set; }
        public Dictionary<string, decimal> BuyPriceList { get; set; }

        public string Description { get; set; }
    }
}
