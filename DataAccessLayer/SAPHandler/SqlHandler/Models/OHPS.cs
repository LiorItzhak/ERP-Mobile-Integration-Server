using System;
using System.Collections.Generic;

namespace DataAccessLayer.SAPHandler.SqlHandler.Models
{
    public partial class OHPS
    {
        public int posID { get; set; }
        public string name { get; set; }
        public string descriptio { get; set; }
        public string LocFields { get; set; }
    }
}
