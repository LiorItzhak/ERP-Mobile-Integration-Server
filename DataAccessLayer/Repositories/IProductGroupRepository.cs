using DataAccessLayer.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public interface IProductGroupRepository : IReadOnlyRepository<ProductGroupEntity,int>
    {
        
    }
}
