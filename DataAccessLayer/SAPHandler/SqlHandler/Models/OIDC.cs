using System;
using System.Collections.Generic;

namespace DataAccessLayer.SAPHandler.SqlHandler.Models
{
    public partial class OIDC
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public short? UserSign { get; set; }
    }
}
