using DataAccessLayer.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Services
{
    public interface IProductsService
    {
        Task<ProductEntity> GetProductAsync(string code);
        Task<IEnumerable<ProductEntity>> GetProductsPageAsync(int page, int size, DateTime? modifiedAfter);
        Task<ProductGroupEntity> GetProductGroupAsync(int code);
        Task<IEnumerable<ProductGroupEntity>> GetProductGroupsPageAsync(int page, int size, DateTime? modifiedAfter);
    }
}
