using DataAccessLayer.Entities.Products;
using DataAccessLayer.Entities.Products.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api.DTOs.Products
{
    public class ProductDto 
    {
        public string Code { get; set; }
        public int GroupCode { get; set; }
        public string Name { get; set; }
        public string NameForeign { get; set; }
        public string Barcode { get; set; }
        public string PictureUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsForSell { get; set; }
        public bool IsForBuy { get; set; }

        //Properties like width length height u_roll etc...
        public List<ProductPropertyDto> Properties { get; set; }
        public string AutoQuantityCalculationExpression { get; set; }
        public string CreationDateTime { get; set; }
        public string LastUpdateDateTime { get; set; }
        public Dictionary<string, decimal> SellPriceList { get; set; }
        public Dictionary<string, decimal> BuyPriceList { get; set; }
        public string Description { get; set; }


    }
}
