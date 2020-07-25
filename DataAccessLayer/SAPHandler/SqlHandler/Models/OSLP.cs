using System;
using System.Collections.Generic;

namespace DataAccessLayer.SAPHandler.SqlHandler.Models
{
    public partial class OSLP
    {
        public int SlpCode { get; set; }
        public string SlpName { get; set; }
        public string Memo { get; set; }
        public decimal? Commission { get; set; }
        public short? GroupCode { get; set; }
        public string Locked { get; set; }
        public string DataSource { get; set; }
        public short? UserSign { get; set; }
        public int? EmpID { get; set; }
        public string Active { get; set; }
        public string Telephone { get; set; }
        public string Mobil { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
    }
}
