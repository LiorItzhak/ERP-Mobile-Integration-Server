using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Impls.Ral
{
    public abstract class WriteableRepository<TEntity, Id> : ReadOnlyRepository<TEntity, Id>,
        IWritableRepository<TEntity, Id> where TEntity : class
    {
        protected WriteableRepository(DbSet<TEntity> dbSet) : base(dbSet)
        {
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
             BeforeModify(entity);
            var result =await   Task.Run(() => DbSet.Update(entity).Entity);
             AfterModify(entity);
            return result;

        }

        public async Task<List<TEntity>> UpdateAsync(List<TEntity> entities)
        {
            entities.ForEach(async x=> BeforeModify(x));
            var result = await Task.Run(() => entities.Select(x => UpdateAsync(x).Result).ToList());
            entities.ForEach(async x=> AfterModify(x));
            return result;

            //  return await Task.WhenAll(entities.Select(async x => await UpdateAsync(x)));
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
             BeforeModify(entity);
            var result =  (await DbSet.AddAsync(entity)).Entity;
             AfterModify(entity);
            return result;
        }

        public async Task<List<TEntity>> AddAsync(List<TEntity> entities)
        {
            entities.ForEach(async x=> BeforeModify(x));
            var result = await Task.Run(() => entities.Select(x => AddAsync(x).Result).ToList());
            entities.ForEach(async x=> AfterModify(x));
            return result;
        }

        public async Task RemoveAsync(Id id)
        {
            var x = await DbSet.FindAsync(id);
            DbSet.Remove(x);
        }

        public async Task RemoveAsync(List<Id> ids)
        {
            await Task.Run(() => ids.ToList().ForEach(x => RemoveAsync(x).Wait()));
        }

        protected virtual void BeforeModify(TEntity entity)
        {
            
        }
        protected virtual  void AfterModify( TEntity entity)
        {
            
        }
    }
}