using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class EmployeeEntity :Entity
    {
        public enum GenderTypes { Male, Female }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sn{get;set;}
        public bool IsActive{get;set;}
        public string FirstName{get;set;}
        public string MiddleName{get;set;}
        public string LastName{get;set;}
        public string ID { get; set; }
        public GenderTypes Gender {get;set;}
        public DateTime? Birthday{get;set;}
        public string JobTitle{get;set;}
        public Department Department{get;set;}
        public JobPosition Position{get;set;}
        public int? ManagerSN {get;set;}
        public int? SalesmanSN{get;set;}
        [ForeignKey("HomeAddressForeignKey")]
        public Address HomeAddress{get;set;}
        [ForeignKey("WorkAddressForeignKey")]

        public Address WorkAddress {get;set;}
        public string HomePhone {get;set;}
        public string OfficePhone{get;set;}
        public string WorkCellular {get;set;}
        public string Fax{get;set;}
        public string Email{get;set;}
        public string PicPath{get;set;}
    }


    public class Department :Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class JobPosition :Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
