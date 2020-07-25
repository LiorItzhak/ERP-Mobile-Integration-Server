using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;

namespace LogicLib.Services.Impl
{
    public class UserLocationService : IUserLocationService
    {
        private readonly IDalService _dalService;

        public UserLocationService(IDalService dalService)
        {
            _dalService = dalService;
        }


        public async Task Add(List<UserLocation> userLocations)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            await transaction.UserLocations.AddAsync(userLocations);
            await transaction.CompleteAsync();
        }

        public async Task<List<UserLocation>> Get(
            int page, int size,
            DateTime fromDateTime,
            DateTime? toDateTime,
            int? employeeSn)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            return await transaction.UserLocations.FindAllAsync(
                x => (!employeeSn.HasValue || x.EmployeeSn == employeeSn)
                     && x.DateTime >= fromDateTime && (!toDateTime.HasValue || toDateTime.Value <= toDateTime),
                PageRequest.Of(page, size, Sort<UserLocation>.By(x => x.DateTime)));
        }

        public async Task<UserLocation> GetLastKnownLocation(int employeeSn)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            return await transaction.UserLocations.FirstOrDefaultAsync(
                x => x.EmployeeSn == employeeSn && x.Latitude.HasValue && x.Longitude.HasValue,
                Sort<UserLocation>.By(x => x.DateTime, OrderType.Desc)
            );
        }
    }
}