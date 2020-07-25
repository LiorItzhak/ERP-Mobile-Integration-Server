using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace Web_Api.DTOs
{
    public class CheckInRequestDto
    {
        public int EmployeeSn { get; set; }
        
        public GeoLocationDto CheckInLocation { get; set; }
        
        public Dictionary<string,object> Properties  { get; set; }
    } 
    
    
    // ReSharper disable once ClassNeverInstantiated.Global
    public class EmployeeTimeClockDto
    {
        public long? Key{get;set;}

        public int EmployeeSn{get;set;}
        
        public string CheckIn {get;set;}
        
        public string CheckOut {get;set;}

        public string Comments { get; set; }
        
        public GeoLocationDto CheckInLocation { get; set; }
        
        public GeoLocationDto CheckOutLocation { get; set; }
        
        public Dictionary<string,object> Properties  { get; set; }
        
    } 
    public class CheckOutRequestDto
    {
        public int EmployeeSn { get; set; }
        
        public GeoLocationDto CheckOutLocation { get; set; }
        
        public Dictionary<string,object> Properties  { get; set; }
        
        public string Comments { get; set; }
        
    } 
    
}