



using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using System.Linq;

using DataAccessLayer.Entities.Documents;
using System.Reflection;
using DataAccessLayer.Entities.Documents.Headers;
using DataAccessLayer.Entities.Documents.Utils;

namespace DataAccessLayer.Repositories.Impls.Ral
{
    public class DocumentRepository<TDocument,TDocumentHeader> 
        :  IDocumentRepository<TDocument, TDocumentHeader> where TDocumentHeader : DocumentHeaderEntity where TDocument : TDocumentHeader, IDocumentEntity
    {
        private readonly RalDbContext _dbContext;
        protected readonly IQueryable<TDocumentHeader> SelectEntityQuery ;
        protected readonly Expression<Func<TDocumentHeader, int>> SelectId = entity =>  entity.Key.Value;
        public DocumentRepository(RalDbContext dbContext)
        {
            _dbContext = dbContext;
            SelectEntityQuery= SelectDocumentFromDb(dbContext);
        }



        public async Task<TDocument> CancelAsync(int docKey)
        {
            var doc = await FindByIdWithItemsAsync(docKey);
            doc.IsCanceled = true;
            doc.IsClosed = true;
            doc.ClosingDate = DateTime.Now;
            return SelectDocumentFromDb(_dbContext).Update(doc).Entity;
        }

        public async Task<TDocument> CloseAsync(int docSn)
        {
            var doc = await FindByIdWithItemsAsync(docSn);
            doc.IsClosed = true;
            doc.ClosingDate = DateTime.Now;
            return SelectDocumentFromDb(_dbContext).Update(doc).Entity;
        }



        public async Task<TDocument> AddAsync(TDocument document)
        {
            document.Sn = Guid.NewGuid().GetHashCode();
            document.CreationDateTime =  DateTime.Now;
            document.LastUpdateDateTime =null;
            //generate unique item number
            var i = 0;
            document.Items.ForEach(x => x.ItemNumber = i++);
            return (await SelectDocumentFromDb(_dbContext).AddAsync(document)).Entity;
        }



        public async Task<TDocument> UpdateAsync(TDocument document)
        {
            document.LastUpdateDateTime = DateTime.Now;

            var i = document.Items.Where(x => x.ItemNumber.HasValue).Max(x=>x.ItemNumber.Value)+1;
            document.Items.Where(x => !x.ItemNumber.HasValue).ToList().ForEach(x => {
                //generate unique item number foreach new item
                x.ItemNumber = i++;
          
                x.OpenQuantity = x.Quantity;
            });
            document.Items.RemoveAll(x => x.Quantity == 0);
            return SelectDocumentFromDb(_dbContext).Update(document).Entity;
        }


        
        public Task<IEnumerable<DocumentsSummery>> SumMonthlyAsync(Expression<Func<TDocumentHeader, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DocumentsSummery>> SumYearlyAsync(Expression<Func<TDocumentHeader, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DocumentsSummery>> SumDailyAsync(Expression<Func<TDocumentHeader, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task CreatePdf(int docKey)
        {
            throw new NotImplementedException();
        }


        public async Task<List<TDocumentHeader>> GetAllAsync(PageRequest pageRequest)
        {
            return await SelectEntityQuery.PagedSortBy(pageRequest).ToListAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TDocumentHeader, bool>> predicate = null)
        {
            var q = SelectEntityQuery;
            if (predicate == null)
                return await q.CountAsync();
            return await q.CountAsync(predicate);
        }

        public async Task<TDocumentHeader> SingleOrDefaultAsync(Expression<Func<TDocumentHeader, bool>> predicate)
        {
            return await SelectEntityQuery.SingleOrDefaultAsync(predicate);
        }

        public  async Task<TDocumentHeader> FirstOrDefaultAsync(Expression<Func<TDocumentHeader, bool>> predicate, Sort<TDocumentHeader> sort = Sort<TDocumentHeader>.Unsorted)
        {
            return await SelectEntityQuery.SortBy(sort).FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TDocumentHeader>> FindAllAsync(Expression<Func<TDocumentHeader, bool>> predicate, PageRequest pageRequest)
        {
            return await SelectEntityQuery.Where(predicate).PagedSortBy(pageRequest).ToListAsync();
        }
        
        public async Task<TDocumentHeader> FindByIdAsync(int id)
        {
            return await SelectEntityQuery
                .Where(x => SelectId.Compile()(x).Equals(id))
                .FirstOrDefaultAsync();
        }
        

        
        public async Task<TDocument> FindByIdWithItemsAsync(int docKey)
        {
             return await SelectDocumentFromDb(_dbContext).Where(d => d.Key == docKey)
                .FirstOrDefaultAsync();
        }


        // ReSharper disable once StaticMemberInGenericType
        private static readonly Dictionary<Type, PropertyInfo> DbSetsCache = new Dictionary<Type, PropertyInfo>();
        
        // ReSharper disable once SuggestBaseTypeForParameter
        private static DbSet<TDocument> SelectDocumentFromDb(RalDbContext dbContext)
        {
            if (!DbSetsCache.ContainsKey(typeof(TDocument)))
                DbSetsCache.Add(typeof(TDocument), dbContext.GetType()
                    .GetProperties()
                    .FirstOrDefault(p => p.PropertyType == typeof(DbSet<TDocument>)));
            var dbSetType = DbSetsCache[typeof(TDocument)];


            if (dbSetType != null)
                return dbSetType.GetValue(dbContext) as DbSet<TDocument>;
            throw new Exception($"Generic type {typeof(TDocument)} invalid for DocumentRepository");
        }


    }
}
