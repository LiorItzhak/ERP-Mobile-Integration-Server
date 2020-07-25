using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Repositories.Impls.SAP
{
    public static class SqlUtils
    {
        // public static readonly Expression<Func<DateTime?, int?, DateTime?>> CalcSapTimeFromDateAndSapTs =
        //  (date, sapTs) => sapTs.HasValue && date.HasValue ? date.Value
        //                  .AddSeconds(sapTs.Value % 100)
        //                  .AddMinutes((sapTs.Value / 100) % 100)
        //                  .AddHours((sapTs.Value / 10000) % 10000) : date;
        //
        //
        // public static Expression<Func<DateTime?, int?, DateTime?>> Time(DateTime? date, int? ts)
        // {
        //     CalcSapTimeFromDateAndSapTs.
        //     var selectId = SelectId;
        //     Expression condition = Expression.Equal(selectId.Body,Expression.Constant(id) );
        //     return Expression.Lambda<Func<TEntity, bool>>(condition, selectId.Parameters);
        // }
    }
}
