using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api.DTOs
{
    public class EmployeeDto
    {
        public enum GenderTypes { Male, Female }

        public int Sn{get;set;} 
        public bool IsActive{get;set;} 
        public string FirstName{get;set;} 
        public string MiddleName{get;set;} 
        public string LastName{get;set;} 
        public string Id{get;set;}
        [JsonConverter(typeof(StringEnumConverter))]
        public GenderTypes Gender{get;set;} 
        public string Birthday{get;set;} 
        public string JobTitle{get;set;} 
        public DepartmentDto Department{get;set;} 
        public JobPositionDto Position{get;set;} 
        public int? ManagerSn{get;set;} 
        public int? SalesmanSn{get;set;} 
        public AddressDto HomeAddress{get;set;} 
        public AddressDto WorkAddress{get;set;} 
        public string HomePhone{get;set;} 
        public string OfficePhone{get;set;} 
        public string WorkCellular{get;set;} 
        public string Fax{get;set;} 
        public string Email{get;set;} 
        public string PicPath{get;set;}

    }


    // ReSharper disable once ClassNeverInstantiated.Global
    public class DepartmentDto 
    {
        public int Code{get;set;} 
        public string Name{get;set;} 
        public string Description{get;set;} 
    }
    // ReSharper disable once ClassNeverInstantiated.Global
    public class JobPositionDto 
    {
        public int Code{get;set;} 
        public string Name{get;set;} 
        public string Description{get;set;} 
    }
}
