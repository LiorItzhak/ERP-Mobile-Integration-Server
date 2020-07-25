using DataAccessLayer.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Impls.Ral
{
    public class ProductGroupRepository : ReadOnlyRepository<ProductGroupEntity,int>,IProductGroupRepository
    {
        public ProductGroupRepository(RalDbContext dbContext) :base(dbContext.ProductGroups) { }
    }
}
