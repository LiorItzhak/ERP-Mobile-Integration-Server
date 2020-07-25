using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public static class Utils
    {
        public static IOrderedQueryable<TSource> OrderBy<TSource, TKey, TdKey>(
            this IQueryable<TSource> source,
            Expression<Func<TSource, TKey>> keySelector,
            Expression<Func<TSource, TdKey>> defaultKeySelector)
        {
            return keySelector == null ? source.OrderBy(defaultKeySelector) : source.OrderBy(keySelector);
        }

        public static IQueryable<TSource> SortBy<TSource>(this IQueryable<TSource> source, Sorted sort)
        {
            if (sort == Sorted.Unsorted)
                return source;

            if(!(sort is Sort<TSource> sorted))
                throw new Exception("Illegal sorted expression type -SortBy ");
          //  return source;
            if (sort.Order == OrderType.Asc)
                return source.OrderBy(sorted.SortBy);
            
            return source.OrderByDescending(sorted.SortBy);
        }

        public static IQueryable<TSource> PagedSortBy<TSource>(this IQueryable<TSource> source,
            PageRequest pageRequest)
        {
            return source.SortBy(pageRequest.SortBy).Skip(pageRequest.Page*pageRequest.Size).Take(pageRequest.Size);
        }
    }
}