using System;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{   
    public enum OrderType { Asc,Desc }

    public abstract class Sorted
    {
        public const Sorted Unsorted = null;
        public abstract OrderType Order { get; }
    }

    public class Sort<TEntity> :Sorted
    {
        public new const Sort<TEntity> Unsorted = null;

        private Sort(Expression<Func<TEntity, object>> sortBy, OrderType order)
        {
            Order = order;
            SortBy = sortBy;
        }
        
        public override OrderType Order { get; }
        
        public Expression<Func<TEntity, object>> SortBy { get; }

        public static Sort<TEntity> By(Expression<Func<TEntity, object>> sortBy, OrderType order = OrderType.Asc)
        {
            return new Sort<TEntity>(sortBy,order);
        }

    }

    public class PageRequest 
    {
        private PageRequest(int page, int size,Sorted sortBy)
        {
            Page = page;
            Size = size;
            SortBy = sortBy;
        }

        public int Page { get;  }
        public int Size { get; }
        public  Sorted SortBy { get; }
        
        public static PageRequest Of<TEntity>(int page, int size,  Sort<TEntity> sort)
        {
            return new PageRequest(page,size,sort);
        }
        
        public static PageRequest Of(int page, int size)
        {
            return new PageRequest(page,size, Sorted.Unsorted);
        }
    }
    

}