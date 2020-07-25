using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace LogicLib.Utils
{
    public  static class Extensions
    {

        public static async Task<byte[]> ToCsvAsync<T>(this IEnumerable<T> records, Type classMapType = null)
        {
            await using var memoryStream = new MemoryStream();
            await using (var streamWriter = new StreamWriter(memoryStream, new UTF8Encoding(true)))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

                if (classMapType != null)
                    csvWriter.Configuration.RegisterClassMap(classMapType);
                
                await csvWriter.WriteRecordsAsync(records);
            }
            return memoryStream.ToArray();
        }
        
        public static IEnumerable<R> CumulativeSum<T,R>(this IEnumerable<T> sequence,R init, Func<R,T,R> add )
        {
            var enumerable = sequence as T[] ?? sequence.ToArray();
            var sum = init;
            foreach(var item in enumerable)
            {
                sum  = add(sum ,item);
                yield return sum;
            }        
        }
        
        public static IEnumerable<T> CumulativeSum<T>(this IEnumerable<T> sequence, Func<T,T,T> add )
        {
            var enumerable = sequence as T[] ?? sequence.ToArray();
            var sum =enumerable.First();
            yield return sum;
            foreach(var item in enumerable.Skip(1))
            {
                sum  = add(sum ,item);
                yield return sum;
            }        
        }
        
        public static T Sum<T>(this IEnumerable<T> sequence, Func<T,T,T> add )
        {
            var enumerable = sequence as T[] ?? sequence.ToArray();
            if (enumerable.Length == 0)
            {
                return default(T);
            }
            var sum =enumerable.First();
            return enumerable.Length >0 ? enumerable.Skip(1).Aggregate(sum, add) : sum;
        }
    }


    public sealed class Monoid<T> 
    {
        public readonly T Zero;
        public readonly Func<T, T, T> Add;

        public Monoid(T zero, Func<T, T, T> add) {
            // Law("Left identity",    (T x) => add(zero, x).Equals(x));
            // Law("Right identity",   (T x) => add(x, zero).Equals(x));
            // Law("Associative",      (T x, T y, T z) => add(add(x, y), z).Equals(add(x, add(y, z))));
            Zero = zero;
            Add = add;
        }

    }
}