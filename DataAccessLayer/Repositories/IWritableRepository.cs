using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{

    public interface IWritableRepository <TEntity, Id> : IReadOnlyRepository<TEntity, Id> where TEntity : class
    {

        Task<TEntity> UpdateAsync(TEntity entity);
        Task<List<TEntity>> UpdateAsync(List<TEntity> entities);
        Task<TEntity> AddAsync(TEntity entity);
        Task<List<TEntity>> AddAsync(List<TEntity> entities);
        Task RemoveAsync(Id id);
        Task RemoveAsync(List<Id> ids);
    }
}
