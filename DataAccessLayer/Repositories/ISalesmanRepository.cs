using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public interface ISalesmanRepository : IReadOnlyRepository<SalesmanEntity,int>
    {
    }
}
