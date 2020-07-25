using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace DataAccessLayer.Repositories.Impls.SAP
{
    public abstract class SapReadOnlyRepository<TEntity, Id> : IReadOnlyRepository<TEntity, Id> where TEntity : class
    {
        protected readonly IQueryable<TEntity> SelectEntityQuery;
        protected readonly Expression<Func<TEntity, Id>> SelectId ;


        public SapReadOnlyRepository(IQueryable<TEntity> selectEntityQuery, Expression<Func<TEntity, Id>> selectId)
        {
            SelectEntityQuery = selectEntityQuery;
            SelectId = selectId;
        }

        public async Task<List<TEntity>> GetAllAsync(PageRequest pageRequest)
        {
            return await SelectEntityQuery
                .PagedSortBy(pageRequest)
                .ToListAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            var q = SelectEntityQuery;
            if (predicate == null)
                return await q.CountAsync();
            return await q.CountAsync(predicate);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await SelectEntityQuery.SingleOrDefaultAsync(predicate);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate,
            Sort<TEntity> sort = Sort<TEntity>.Unsorted)
        {
            return await SelectEntityQuery.SortBy(sort).FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate,
            PageRequest pageRequest)
        {
            return await SelectEntityQuery.Where(predicate).PagedSortBy(pageRequest).ToListAsync();
        }

        
        public async Task<TEntity> FindByIdAsync(Id id)
        {
            return await SelectEntityQuery
                .Where( CompareId(id))
                .SingleOrDefaultAsync();
        }
        
        
        private  Expression<Func<TEntity, bool>> CompareId(Id id)
        {
            var selectId = SelectId;
            Expression condition = Expression.Equal(selectId.Body,Expression.Constant(id) );
            return Expression.Lambda<Func<TEntity, bool>>(condition, selectId.Parameters);
        }
    }
}