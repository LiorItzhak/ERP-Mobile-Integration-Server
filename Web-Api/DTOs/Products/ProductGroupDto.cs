using DataAccessLayer.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api.DTOs.Products
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ProductGroupDto
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string PictureUrl{ get; set; }
        public string CreationDateTime { get; set; }
        public string LastUpdateDateTime { get; set; }
    }
}
