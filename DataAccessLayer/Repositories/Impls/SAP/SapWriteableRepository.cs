using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccessLayer.SAPHandler.DiApiHandler.SapDbSets;

namespace DataAccessLayer.Repositories.Impls.SAP
{
    public abstract class SapWriteableRepository <TEntity,  Id> : SapReadOnlyRepository <TEntity, Id> , IWritableRepository<TEntity,Id> where TEntity : class
    {
        protected readonly DiSet<TEntity,Id> DiSet;

        // ReSharper disable once PublicConstructorInAbstractClass
        public SapWriteableRepository(IQueryable<TEntity> selectEntityQuery, Expression<Func<TEntity, Id>> selectId,DiSet<TEntity,Id> diSet) :base(selectEntityQuery,selectId)
        {
            DiSet = diSet;
        }
        
        //sap di api dont support async methods:
        //not really a async method- its only implemented to support the interface
        public Task<TEntity> AddAsync(TEntity entity)
        {
            return Task.Run(() => DiSet.Add(entity));
        }

        public Task<List<TEntity>> AddAsync(List<TEntity> entities)
        {
            return Task.Run(() => entities.Select(x => DiSet.Add(x)).ToList());
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.Run(() => DiSet.Update(entity));
        }

        public Task<List<TEntity>> UpdateAsync(List<TEntity> entities)
        {
            return Task.Run(() => entities.Select(customer => DiSet.Update(customer)).ToList());
        }

        public Task RemoveAsync(Id id)
        {
            return Task.Run(() => DiSet.Remove(id));
        }

        public Task RemoveAsync(List<Id> ids)
        {
            return Task.Run(() => ids.ToList().ForEach(id => DiSet.Remove(id)));
        }


 

    }
}