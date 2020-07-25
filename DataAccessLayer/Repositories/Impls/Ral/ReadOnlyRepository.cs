using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Impls.Ral
{
    public abstract class ReadOnlyRepository  <TEntity,  Id> : IReadOnlyRepository <TEntity, Id> where TEntity : class
    {
        protected readonly DbSet<TEntity> DbSet;

        public ReadOnlyRepository(DbSet<TEntity> dbSet )
        {
            DbSet = dbSet;
        }



        public async Task<List<TEntity>> GetAllAsync(PageRequest pageRequest)
        {
            return await DbSet.PagedSortBy(pageRequest).ToListAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            var q = DbSet;
            if (predicate == null)
                return await q.CountAsync();
            return await q.CountAsync(predicate);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.SingleOrDefaultAsync(predicate);
        }

        public  async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, Sort<TEntity> sort = Sort<TEntity>.Unsorted)
        {
            return await DbSet.SortBy(sort).FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, PageRequest pageRequest)
        {
            return await DbSet.Where(predicate).PagedSortBy(pageRequest).ToListAsync();
        }
        
        public async Task<TEntity> FindByIdAsync(Id id)
        {
            return await DbSet.FindAsync(id);
        }
        
    }
}