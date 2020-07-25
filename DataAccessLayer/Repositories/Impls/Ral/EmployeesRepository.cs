using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.SAPHandler.DiApiHandler;
using DataAccessLayer.SAPHandler.SqlHandler.Models;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DataAccessLayer.Repositories.Impls.Ral
{
    public class EmployeesRepository : ReadOnlyRepository<EmployeeEntity,int>, IEmployeeRepository
    {
        private readonly RalDbContext _dbContext;
        public EmployeesRepository(RalDbContext dbContext):base(dbContext.Employees)
        {
            _dbContext = dbContext;
        }
    }
}