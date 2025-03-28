using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Commons
{
    [PublicAPI]
    public static class EnumerableExtensions
    {
        private static string _minMaxExceptionMessage = "Sequence contains no elements";
        
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return !source.Any();
        }
        
        // ReSharper disable PossibleMultipleEnumeration
        public static T Random<T>(this IEnumerable<T> source, Random random)
        {
            var index = random.Next(source.Count());
            return source.ElementAt(index);
        }
        // ReSharper restore PossibleMultipleEnumeration
        
        // ReSharper disable PossibleMultipleEnumeration
        public static IEnumerable<(T Element1, T Element2)> GetAllPairs<T>(this IEnumerable<T> source)
        {
            return source.SelectMany((_, i) => source.Where((_, j) => i < j), (x, y) => (x, y));
        }
        // ReSharper restore PossibleMultipleEnumeration
        
        public static IEnumerable<(TOne Element1, TTwo Element2)> GetAllPairs<TOne, TTwo>(this IEnumerable<TOne> source, IList<TTwo> target)
        {
            return source.SelectMany(s => target.Select(t => (s, t)));
        }

        public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            var comparer = Comparer<TKey>.Default;
            using var sourceIterator = source.GetEnumerator();
            if (!sourceIterator.MoveNext())
            {
                throw new InvalidOperationException(_minMaxExceptionMessage);
            }
            var min = sourceIterator.Current;
            var minKey = selector(min);
            while (sourceIterator.MoveNext())
            {
                var candidate = sourceIterator.Current;
                var candidateProjected = selector(candidate);
                if (comparer.Compare(candidateProjected, minKey) >= 0) continue;
                min = candidate;
                minKey = candidateProjected;
            }
            return min;
        }

        public static IEnumerable<TSource> MinsBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            var comparer = Comparer<TKey>.Default;
            using var sourceIterator = source.GetEnumerator();
            if (!sourceIterator.MoveNext())
            {
                throw new InvalidOperationException(_minMaxExceptionMessage);
            }
            var min = new List<TSource> { sourceIterator.Current };
            var minKey = selector(min[0]);
            while (sourceIterator.MoveNext())
            {
                var candidate = sourceIterator.Current;
                var candidateProjected = selector(candidate);
                switch (comparer.Compare(candidateProjected, minKey))
                {
                    case < 0:
                        min.Clear();
                        min.Add(candidate);
                        minKey = candidateProjected;
                        break;
                    case 0:
                        min.Add(candidate);
                        break;
                }
            }
            return min;
        }

        public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            var comparer = Comparer<TKey>.Default;
            using var sourceIterator = source.GetEnumerator();
            if (!sourceIterator.MoveNext())
            {
                throw new InvalidOperationException(_minMaxExceptionMessage);
            }
            var max = sourceIterator.Current;
            var maxKey = selector(max);
            while (sourceIterator.MoveNext())
            {
                var candidate = sourceIterator.Current;
                var candidateProjected = selector(candidate);
                if (comparer.Compare(candidateProjected, maxKey) <= 0) continue;
                max = candidate;
                maxKey = candidateProjected;
            }
            return max;
        }

        public static IEnumerable<TSource> MaxsBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            var comparer = Comparer<TKey>.Default;
            using var sourceIterator = source.GetEnumerator();
            if (!sourceIterator.MoveNext())
            {
                throw new InvalidOperationException(_minMaxExceptionMessage);
            }
            var max = new List<TSource> { sourceIterator.Current };
            var maxKey = selector(max[0]);
            while (sourceIterator.MoveNext())
            {
                var candidate = sourceIterator.Current;
                var candidateProjected = selector(candidate);
                switch (comparer.Compare(candidateProjected, maxKey))
                {
                    case > 0:
                        max.Clear();
                        max.Add(candidate);
                        maxKey = candidateProjected;
                        break;
                    case 0:
                        max.Add(candidate);
                        break;
                }
            }
            return max;
        }
        
        public static IEnumerable<T> ClearNull<T>(this IEnumerable<T> source)
        {
            return source.Where(elem => !Equals(elem, default(T)));
        }
        
        public static IEnumerable<T> OfTypeName<T>(this IEnumerable<T> source, string typeName)
        {
            return source.Where(elem => elem!.GetType().Name.Equals(typeName));
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source) action(item);
        }
        
        public static void ForEachIndex<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            var index = 0;
            foreach (var item in source) action(item, index++);
        }
        
        public static int IndexOf<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.Select((item, index) => new { Item = item, Index = index })
                .First(el => predicate(el.Item))
                .Index;
        }
        
        public static IEnumerable<int> IndicesOf<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.Select((item, index) => new { Item = item, Index = index })
                .Where(el => predicate(el.Item))
                .Select(el => el.Index);
        }

        public static IEnumerable<int> IndicesOf<T>(this IEnumerable<T> source, T value)
        {
            var index = 0;
            foreach (var item in source)
            {
                if (item!.Equals(value)) yield return index;
                index++;
            }
        }
        
        public static IEnumerable<int> IndicesOf<T>(this IEnumerable<T> source, List<T> values)
        {
            var index = 0;
            foreach (var item in source)
            {
                if (values.Contains(item!)) yield return index;
                index++;
            }
        }
        
        // ReSharper disable PossibleMultipleEnumeration
        public static bool Equals<T>(this IEnumerable<T> source1, IEnumerable<T> source2)
        {
            var firstNotSecond = source1.Except(source2);
            var secondNotFirst = source2.Except(source1);
            return source1.Count() == source2.Count() && !firstNotSecond.Any() && !secondNotFirst.Any();
        }
        // ReSharper restore PossibleMultipleEnumeration

        // ReSharper disable PossibleMultipleEnumeration
        public static bool EqualsWithOrder<T>(this IEnumerable<T> source1, IEnumerable<T> source2)
        {
            return source1.Count() == source2.Count() && source1.Intersect(source2).SequenceEqual(source2);
        }
        // ReSharper restore PossibleMultipleEnumeration
        
        public static IEnumerable<T> GetRange<T>(this IEnumerable<T> source, int index, int count)
        {
            return source.Skip(index).Take(count);
        }
    }
}
