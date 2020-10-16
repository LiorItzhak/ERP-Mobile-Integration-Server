using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DataAccessLayer.Entities.Documents;

namespace DataAccessLayer.Entities.BusinessPartners
{
    public class Activity : Entity, ICloneable
    {
        [Key]//NONE for SapActivityRep
        public int? Code { get; set; }
        public string BusinessPartnerCode { get; set; }
        public int? HandleByEmployeeCode { get; set; }

        public ActionType Action { get; set; }
        public int TypeCode { get; set; } 
        public int? SubjectCode { get; set; }

        
        public string  Details { get; set; }
        public string  Notes { get; set; }
        

        public DateTime BeginDateTime { get; set; }
        public int? DurationMinutes { get; set; }
        
        
        public DateTime? CreationDateTime { get; set; }
        
      //  [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LastModifiedDateTime { get; set; }

        public DateTime? CloseDate { get; set; }
        
        public bool IsClosed { get; set; }
        public bool IsActive { get; set; }
        public int? BaseActivity { get; set; }

        public DocReferencedEntity Document { get; set; }
        
        public enum ActionType { PhoneCall,Meeting,Task,Note,Campaign,Other }

       
        
        
        protected bool Equals(Activity other)
        {
            //ignore last modified
            return Code == other.Code && BusinessPartnerCode == other.BusinessPartnerCode && HandleByEmployeeCode == other.HandleByEmployeeCode && Action == other.Action && TypeCode == other.TypeCode && SubjectCode == other.SubjectCode && Details == other.Details && Notes == other.Notes && BeginDateTime.Equals(other.BeginDateTime) && DurationMinutes == other.DurationMinutes && Nullable.Equals(CreationDateTime, other.CreationDateTime) && Nullable.Equals(LastModifiedDateTime, other.LastModifiedDateTime) && Nullable.Equals(CloseDate, other.CloseDate) && IsClosed == other.IsClosed && IsActive == other.IsActive && BaseActivity == other.BaseActivity && Equals(Document, other.Document);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Activity) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Code);
            hashCode.Add(BusinessPartnerCode);
            hashCode.Add(HandleByEmployeeCode);
            hashCode.Add((int) Action);
            hashCode.Add(TypeCode);
            hashCode.Add(SubjectCode);
            hashCode.Add(Details);
            hashCode.Add(Notes);
            hashCode.Add(BeginDateTime);
            hashCode.Add(DurationMinutes);
            hashCode.Add(CreationDateTime);
            hashCode.Add(LastModifiedDateTime);
            hashCode.Add(CloseDate);
            hashCode.Add(IsClosed);
            hashCode.Add(IsActive);
            hashCode.Add(BaseActivity);
            hashCode.Add(Document);
            return hashCode.ToHashCode();
        }

        public override string ToString()
        {
            var propertyStrings = from prop in GetType().GetProperties()
                select $"{prop.Name}={prop.GetValue(this)}";
            return string.Join(", ", propertyStrings);
            
        }

        public object Clone()
        {
            return new Activity
            {
                Code = Code,
                BusinessPartnerCode = BusinessPartnerCode,
                HandleByEmployeeCode = HandleByEmployeeCode,
                Action = Action,
                TypeCode = TypeCode,
                SubjectCode = SubjectCode,
                Details = Details,
                Notes = Notes,
                BeginDateTime = BeginDateTime,
                DurationMinutes = DurationMinutes,
                CreationDateTime = CreationDateTime,
                LastModifiedDateTime = LastModifiedDateTime,
                CloseDate = CloseDate,
                IsClosed = IsClosed,
                IsActive = IsActive,
                BaseActivity = BaseActivity,
                Document = Document
            };
        }
    }

    public class ActivityType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

    }
    
    

    public class ActivitySubject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        public int TypeCode { get; set; }

        public string Name { get; set; }
        public bool IsActive { get; set; }

    }

}