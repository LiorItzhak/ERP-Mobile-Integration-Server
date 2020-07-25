using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// ReSharper disable All

namespace DataAccessLayer.Entities
{
    public class UserLocation :Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Key { get; set; }
        public int EmployeeSn { get; set; }
        public DateTime DateTime { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? ErrorCode { get; set; }
        public string DeviceId { get; set; }
        
        public Dictionary<string,object> MetaData{ get; set; }


    }
}