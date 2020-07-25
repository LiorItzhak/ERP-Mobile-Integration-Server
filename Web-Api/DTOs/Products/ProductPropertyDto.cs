using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api.DTOs.Products
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ProductPropertyDto
    {
        public string Code { get; set; }
        public object DefaultValue { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum PropertyType { Decimal, Int, Text, Choice, Date }
        public PropertyType Type { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
        public string[] Choices { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int? MaxDaysFromNow { get; set; }
        //Unit of measurement
        public string UOM { get; set; }
    }
}
