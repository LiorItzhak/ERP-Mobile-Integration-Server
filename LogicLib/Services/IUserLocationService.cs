using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace LogicLib.Services
{
    public interface IUserLocationService
    {
       Task Add(List<UserLocation> userLocations);

       Task<List<UserLocation>> Get(int page,int size, DateTime fromDateTime, DateTime? toDateTime = null,int? employeeSn = null);

       Task<UserLocation> GetLastKnownLocation(int employeeSn);

    }
    
    
}