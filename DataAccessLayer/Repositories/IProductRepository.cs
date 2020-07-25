using DataAccessLayer.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IProductRepository : IReadOnlyRepository<ProductEntity, string>
    {
        Task<IEnumerable<ProductEntity>> GetAllActiveItemsForeSellAsync(int page, int size);

    }
}
