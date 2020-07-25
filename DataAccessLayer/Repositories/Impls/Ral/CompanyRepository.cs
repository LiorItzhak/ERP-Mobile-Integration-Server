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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly RalDbContext _dbContext;
        public CompanyRepository(RalDbContext dbContext)
        {
          _dbContext = dbContext;
        }

        public CompanyEntity Get()
        {
            return _dbContext.Companies.FirstOrDefault();
          
        }

        public async Task<CompanyEntity> GetAsync()
        {
            return await _dbContext.Companies.FirstOrDefaultAsync();

        }
    }
}
