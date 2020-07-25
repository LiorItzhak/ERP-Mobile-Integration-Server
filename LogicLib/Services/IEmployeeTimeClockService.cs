using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace LogicLib.Services
{
    public interface IEmployeeTimeClockService
    {
        /// <summary>
        /// This method preform check-in for the applicant employee
        /// only an active employee can check in
        /// if the applicant is already checked in throws <exception cref="InvalidOperationException"/>
        /// </summary>
        Task<EmployeeTimeClock> CheckInAsync(CheckInRequest checkInRequest,CancellationToken cancellationToken = default);



        
        /// <summary>
        /// This method preform check-out for the applicant employee
        /// if the applicant is not checked in throws <exception cref="InvalidOperationException"/>
        /// </summary>
        Task<EmployeeTimeClock> CheckOutAsync(CheckOutRequest checkOutRequest,CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the last check in of the applicant employee
        /// </summary>
        Task<EmployeeTimeClock> GetLastTimeClock(int employeeSn);
        
        /// <summary>
        /// Get the last check in of the applicant employee
        /// </summary>
        Task<IEnumerable<EmployeeTimeClock>> GeTimeClocks(DateTimeOffset fromDate, DateTimeOffset toDate,int page, int size, int? employeeSn = null,bool considerTimeOfDay = false);

        Task<byte[]> GenerateCsvBytes(DateTimeOffset fromDate, DateTimeOffset toDate, int? employeeSn = null,bool considerTimeOfDay = false);

    }


    public class CheckInRequest
    {
        public int EmployeeSn { get; set; }
        
        public DataAccessLayer.Entities.GeoLocation CheckInLocation { get; set; }
        
        public Dictionary<string,object> Properties  { get; set; }
    }
    
    public class CheckOutRequest
    {
        public int EmployeeSn { get; set; }
        
        public DataAccessLayer.Entities.GeoLocation CheckOutLocation { get; set; }
        
        public Dictionary<string,object> Properties  { get; set; }
        
        public string Comments { get; set; }
    }
    

    
}