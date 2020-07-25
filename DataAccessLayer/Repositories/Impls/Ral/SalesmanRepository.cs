using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.SAPHandler.DiApiHandler;
using DataAccessLayer.SAPHandler.SqlHandler.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DataAccessLayer.Repositories.Impls.Ral
{
    public class SalesmanRepository :ReadOnlyRepository<SalesmanEntity,int>, ISalesmanRepository
    {
        private readonly RalDbContext _dbContext;

        public SalesmanRepository(RalDbContext dbContext) :base(dbContext.Salesmen)
        {
            _dbContext = dbContext;
        }

        
    }
}