using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IReadOnlyRepository <TEntity, in Id> :IRepository where TEntity : class
    {
        Task<TEntity> FindByIdAsync(Id id);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, Sort<TEntity> sorted = Sort<TEntity>.Unsorted);
        Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, PageRequest pageRequest);
        Task<List<TEntity>> GetAllAsync(PageRequest pageRequest);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);
    }
}
