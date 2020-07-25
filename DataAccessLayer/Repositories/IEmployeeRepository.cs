using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public interface IEmployeeRepository : IReadOnlyRepository<EmployeeEntity,int>
    {

    }
}
