using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static DataAccessLayer.SAPHandler.DiApiHandler.SapDiApiContext;

namespace DataAccessLayer.SAPHandler.DiApiHandler.SapDbSets
{

    public interface IDiSet<TEntity>
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
    }
    public abstract class DiSet<TEntity,Id> : IDiSet<TEntity>
    {
        protected readonly CompanyContext Context;
        protected DiSet(CompanyContext context)
        {
            Context = context;
        }

        public abstract TEntity Add(TEntity entity);


        public abstract TEntity Update(TEntity entity);

        public abstract void Remove(Id id);
    }



}
