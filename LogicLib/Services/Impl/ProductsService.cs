using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities.Products;
using DataAccessLayer.Repositories;

namespace LogicLib.Services.Impl
{
    public class ProductsService : IProductsService
    {
        private readonly IDalService _dalService;

        public ProductsService(IDalService dalService)
        {
            _dalService = dalService;
        }

        public async Task<IEnumerable<ProductGroupEntity>> GetProductGroupsPageAsync(int page, int size, DateTime? modifiedAfter)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            modifiedAfter = modifiedAfter?.Date;
            var productGroups = await transaction.ProductGroups.FindAllAsync(
                x => !modifiedAfter.HasValue || (x.LastUpdateDateTime != null && x.LastUpdateDateTime > modifiedAfter) ||
                     (x.LastUpdateDateTime == null && x.CreationDateTime > modifiedAfter),
                PageRequest.Of(page, size, Sort<ProductGroupEntity>.By(x => x.CreationDateTime)));
            return productGroups;
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsPageAsync(int page, int size, DateTime? modifiedAfter)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            var products = await transaction.Products
                //.GetAllAsync( PageRequest.Of(page, size, Sort<ProductEntity>.By(x => x.CreationDateTime)));
                 .FindAllAsync(x => !modifiedAfter.HasValue || (x.LastUpdateDateTime.HasValue && x.LastUpdateDateTime > modifiedAfter) || (!x.LastUpdateDateTime.HasValue && x.CreationDateTime > modifiedAfter),
                     PageRequest.Of(page, size, Sort<ProductEntity>.By(x => x.CreationDateTime)));

            return products;
        }

        public async Task<ProductEntity> GetProductAsync(string code)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            var products = await transaction.Products.FindByIdAsync(code);
            return products;
        }

        public async Task<ProductGroupEntity> GetProductGroupAsync(int code)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            var productGroup = await transaction.ProductGroups.FindByIdAsync(code);
            return productGroup;
        }
    }
}
