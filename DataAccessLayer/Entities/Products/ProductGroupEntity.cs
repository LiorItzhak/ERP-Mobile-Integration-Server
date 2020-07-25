using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities.Products
{
    public class ProductGroupEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }

    }
}
