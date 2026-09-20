using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Commons
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> ClearNull<TSource>(this IEnumerable<TSource> source)
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.Where(elem => !Equals(elem, null));
        }
        
        public static IEnumerable<TSource> OfTypeName<TSource>(this IEnumerable<TSource> source, string typeName)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (typeName == null) throw new ArgumentNullException(nameof(typeName));

            return source.Where(elem => elem is not null && elem.GetType().Name.Equals(typeName));
        }

        public static IEnumerable<(TSource Item, int Index)> Index<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return source.Select((item, index) => (item, index))
                .Where(x => predicate(x.item));
        }

        public static IEnumerable<(TSource Item, int Index)> Index<TSource>(this IEnumerable<TSource> source, TSource value)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (value == null) throw new ArgumentNullException(nameof(value));

            return source.Select((item, index) => (item, index))
                .Where(x => Equals(x.item, value));
        }
        
        public static IEnumerable<(TSource Item, int Index)> Index<TSource>(this IEnumerable<TSource> source, IReadOnlyCollection<TSource> values)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (values == null) throw new ArgumentNullException(nameof(values));

            return source.Select((item, index) => (item, index))
                .Where(x => values.Contains(x.item));
        }
        
        public static IEnumerable<TSource> GetRange<TSource>(this IEnumerable<TSource> source, int index, int count)
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.Skip(index).Take(count);
        }

        [PublicAPI]
        public static IEnumerable<TSource> AggregateIntermediate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func, TSource? seed = default)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (func == null) throw new ArgumentNullException(nameof(func));
            if (seed == null) throw new ArgumentNullException(nameof(seed));

            foreach (var item in source)
            {
                seed = func(seed, item);
                yield return seed;
            }
        }
        
        [PublicAPI]
        public static IEnumerable<object> Flatten(this object[] items)
        {
            foreach (var item in items)
            {
                if (item is IEnumerable enumerable and not string)
                {
                    foreach (var nested in enumerable.Cast<object>().Flatten())
                    {
                        yield return nested;
                    }
                }
                else
                {
                    yield return item;
                }
            }
        }

        [PublicAPI]
        public static IEnumerable<object> Flatten(this IEnumerable items)
        {
            foreach (var item in items)
            {
                if (item is IEnumerable enumerable and not string)
                {
                    foreach (var nested in enumerable.Cast<object>().Flatten())
                    {
                        yield return nested;
                    }
                }
                else
                {
                    yield return item;
                }
            }
        }
    }
}