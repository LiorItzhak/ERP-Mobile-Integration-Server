using DataAccessLayer.Entities;
using LogicLib.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Services
{
    public interface IEmployeesService
    {
        Task<long> CountEmployeesAsync();
        //Task<EmployeeEntity> UpdateEmployeeAsync(int sn, EmployeeEntity employee);
        //Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity employee);
        Task<EmployeeEntity> FindEmployeeBySnAsync(int sn);
        Task<IEnumerable<EmployeeEntity>> GetEmployeesPageAsync(int page,int size=20,DateTime? modifiedAfter = null);


    }
}
