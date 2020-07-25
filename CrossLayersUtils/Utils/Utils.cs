using System;
using System.Threading;
using System.Threading.Tasks;

namespace CrossLayersUtils.Utils
{
    public static class Utils
    {
        public static DateTime ToMillisecondPrecision(this DateTime d) {
            return new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute,
                d.Second, d.Millisecond, d.Kind);
        }
        
        
//        public static async Task<T> WithCancellation<T>(this Task<T> task, CancellationToken cancellationToken)
//        {
//            return await Task.Run(async () => await task, cancellationToken);
//                
////                
////                task.IsCompleted // fast-path optimization
////                ? task
////                : task.ContinueWith(
////                    completedTask => completedTask.GetAwaiter().GetResult(),
////                    cancellationToken,
////                    TaskContinuationOptions.ExecuteSynchronously,
////                    TaskScheduler.Default);
//        }



    }
}