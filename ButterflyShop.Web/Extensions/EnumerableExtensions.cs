using System;
using System.Collections.Generic;
using System.Linq;

namespace ButterflyShop.Web.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Random<T>(this IEnumerable<T> items, int count) => items.OrderBy(x => Guid.NewGuid()).Take(count);
        public static T Random<T>(this IEnumerable<T> items) => items.ElementAt(new Random().Next(items.Count()));

        public static IEnumerable<IEnumerable<T>> ChunkBy<T>(this IEnumerable<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
