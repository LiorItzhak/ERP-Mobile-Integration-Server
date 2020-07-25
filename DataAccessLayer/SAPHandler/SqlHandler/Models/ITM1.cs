using System;
using System.Collections.Generic;

namespace DataAccessLayer.SAPHandler.SqlHandler.Models
{
    public partial class ITM1
    {
        public string ItemCode { get; set; }
        public short PriceList { get; set; }
        public decimal? Price { get; set; }
        public string Currency { get; set; }
        public string Ovrwritten { get; set; }
        public decimal? Factor { get; set; }
        public int? LogInstanc { get; set; }
        public string ObjType { get; set; }
        public decimal? AddPrice1 { get; set; }
        public string Currency1 { get; set; }
        public decimal? AddPrice2 { get; set; }
        public string Currency2 { get; set; }
        public string Ovrwrite1 { get; set; }
        public string Ovrwrite2 { get; set; }
        public short? BasePLNum { get; set; }
    }
}
