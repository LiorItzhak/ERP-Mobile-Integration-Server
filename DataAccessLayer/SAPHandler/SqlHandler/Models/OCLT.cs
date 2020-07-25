using System;
using System.Collections.Generic;

namespace DataAccessLayer.SAPHandler.SqlHandler.Models
{
    public partial class OCLT
    {
        public short Code { get; set; }
        public string Name { get; set; }
        public string DataSource { get; set; }
        public short? UserSign { get; set; }
        public string Active { get; set; }
    }
}
