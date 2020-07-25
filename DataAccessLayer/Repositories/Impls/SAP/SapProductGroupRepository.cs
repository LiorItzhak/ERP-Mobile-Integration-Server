using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccessLayer.SAPHandler.SqlHandler.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DataAccessLayer.SAPHandler.DiApiHandler;
using DataAccessLayer.Entities.Products;
using DataAccessLayer.SAPHandler.SqlHandler.DbContexts;

namespace DataAccessLayer.Repositories.Impls.SAP
{
    public class SapProductGroupRepository : SapReadOnlyRepository<ProductGroupEntity, int>, IProductGroupRepository
    {
        private readonly SapSqlDbContext _dbContext;
        private readonly SapDiApiContext _diApiContext;

        public SapProductGroupRepository(SapSqlDbContext dbContext, SapDiApiContext diApiContext)
            : base(SelectItemGroupEntity(dbContext), x => x.Code)
        {
            _dbContext = dbContext;
            _diApiContext = diApiContext;
        }


        private static IQueryable<ProductGroupEntity> SelectItemGroupEntity(SapSqlDbContext dbContext)
        {
            return dbContext.OITB.Select(AsItemGroupEntity);
        }

        private static Expression<Func<OITB, ProductGroupEntity>> AsItemGroupEntity =
            a => new ProductGroupEntity
            {
                Code = a.ItmsGrpCod,
                Name = a.ItmsGrpNam,
                CreationDateTime = a.createDate  ?? a.updateDate ,
                LastUpdateDateTime = a.updateDate??a.createDate,
                PictureUrl = Convert.ToString(a.ItmsGrpCod) + ".jpg"
            };
    }
}