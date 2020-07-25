using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.BusinessPartners;
using DataAccessLayer.Repositories;
using LogicLib.Utils;

namespace LogicLib.Services.Impl
{
    public class EmployeeService : IEmployeesService
    {
        private readonly IDalService _dalService;

        public EmployeeService(IDalService dalService)
        {
            _dalService = dalService;
        }


        public async Task<long> CountEmployeesAsync()
        {
            using var transaction = _dalService.CreateUnitOfWork();
            return await transaction.Employees.CountAsync();
        }

        public async Task<IEnumerable<EmployeeEntity>> GetEmployeesPageAsync(int page, int size = 20,
            DateTime? modifiedAfter = null)

        {
            using var transaction = _dalService.CreateUnitOfWork();
            return await transaction.Employees
                .GetAllAsync(PageRequest.Of(page, size, Sort<EmployeeEntity>.By(x => x.Sn)));
        }

        public async Task<EmployeeEntity> FindEmployeeBySnAsync(int sn)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            return await transaction.Employees.FindByIdAsync(sn);
        }
    }
}