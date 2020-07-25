using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.SAPHandler.DiApiHandler;
using DataAccessLayer.SAPHandler.SqlHandler.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Impls.Ral;
using DataAccessLayer.SAPHandler.SqlHandler.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace DataAccessLayer.Repositories.Impls.SAP
{
    public class SapSalesmanRepository :SapReadOnlyRepository<SalesmanEntity,int>, ISalesmanRepository
    {
        private readonly SapSqlDbContext _dbContext;
        private readonly SapDiApiContext _diApiContext;

        public SapSalesmanRepository(SapSqlDbContext dbContext, SapDiApiContext diApiContext)
        :base(SelectSalesmanFromDb(dbContext),x=>x.Sn)
        {
            _dbContext = dbContext;
            _diApiContext = diApiContext;
        }
        
        private static IQueryable<SalesmanEntity> SelectSalesmanFromDb(SapSqlDbContext dbContext)
        {
            return dbContext.OSLP.Select(AsSalesmanEntity).OrderBy(s=>s.Sn);
        }

        private static readonly Expression<Func<OSLP, SalesmanEntity>> AsSalesmanEntity =
            (s) => new SalesmanEntity
            {
                Name = s.SlpName,
                Sn = s.SlpCode,
                Mobile = s.Mobil,
                Email = s.Email,
                ActiveStatus = s.Active == "Y" ? SalesmanEntity.Status.Active : SalesmanEntity.Status.NoActive
            };

    }
}
