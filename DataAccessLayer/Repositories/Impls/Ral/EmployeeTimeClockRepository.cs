using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Impls.Ral
{
    public class EmployeeTimeClockRepository : WriteableRepository<EmployeeTimeClock,long>, IEmployeeTimeClockRepository
    {
        public EmployeeTimeClockRepository(RalDbContext dbContext) : base(dbContext.EmployeeTimeClocks) { }
        
    }
}