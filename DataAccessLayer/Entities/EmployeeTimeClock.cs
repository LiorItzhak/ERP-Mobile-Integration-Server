using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class EmployeeTimeClock :Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Key{get;set;}

        public int EmployeeSn{get;set;}
        
        public DateTimeOffset  CheckIn {get;set;}
        
        public DateTimeOffset? CheckOut {get;set;}

        public string Comments { get; set; }
        
        public GeoLocation CheckInLocation { get; set; }
        
        public GeoLocation CheckOutLocation { get; set; }
        
        public Dictionary<string,object> Properties  { get; set; }
    }
}