using System;
using System.Collections.Generic;

namespace DataAccessLayer.SAPHandler.SqlHandler.Models
{
    public partial class OUDP
    {
        public short Code { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public short? UserSign { get; set; }
        public string Father { get; set; }
    }
}
