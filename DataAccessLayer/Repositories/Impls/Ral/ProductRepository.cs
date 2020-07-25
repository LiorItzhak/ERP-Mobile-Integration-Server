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
    public class ProductRepository :ReadOnlyRepository<ProductEntity,string>,IProductRepository
    {
        private readonly RalDbContext _dbContext;

        public ProductRepository(RalDbContext dbContext) :base(dbContext.Products)
        {
            _dbContext = dbContext;
        }

      

        public async Task<IEnumerable<ProductEntity>> GetAllActiveItemsForeSellAsync(int page, int size)
        {
            return await SelectItems().Where(i => i.IsActive && i.IsForSell )
                .Skip(page * size)
                .Take(size)
                .ToArrayAsync();
        }

        private IQueryable<ProductEntity> SelectItems()
        {
            return _dbContext.Products.Select(i=>i);
        }


    }
}
