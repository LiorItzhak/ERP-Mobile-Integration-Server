// ReSharper disable ClassNeverInstantiated.Global

using System.Collections.Generic;

namespace Web_Api.DTOs
{
    public class UserLocationDto
    {
        public int EmployeeSn { get; set; }
        public string DateTime { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? ErrorCode { get; set; }
        public Dictionary<string,object> MetaData{ get; set; }
    }
}