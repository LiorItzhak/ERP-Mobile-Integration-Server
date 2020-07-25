using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Web_Api.DTOs.Documents;
// ReSharper disable ClassNeverInstantiated.Global

namespace Web_Api.DTOs
{
    public class ActivityDto
    {
        public int? Code { get; set; }
        public string BusinessPartnerCode { get; set; }
        public int? HandleByEmployeeCode { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ActionType Action { get; set; }
        
        public int TypeCode { get; set; } 
        public int? SubjectCode { get; set; }

        
        public string  Details { get; set; }
        public string  Notes { get; set; }

        public string BeginDateTime { get; set; }
        public int? DurationMinutes { get; set; }
        
        public string CreationDateTime { get; set; }
        public string LastModifiedDateTime { get; set; }

        public string CloseDate { get; set; }
        
        public bool IsClosed { get; set; }
        public bool IsActive { get; set; }
        public int? BaseActivity { get; set; }

        public DocItemDto.DocReferenceDto Document { get; set; }
        
        public enum ActionType { PhoneCall,Meeting,Task,Note,Campaign,Other }
        
    }

    public class ActivityTypeDto
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

    }

    public class ActivitySubjectDto
    {
        public int Code { get; set; }
        public int TypeCode { get; set; }

        public string Name { get; set; }
        public bool IsActive { get; set; }

    }
}