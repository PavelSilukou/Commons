using System;
using System.Collections.Generic;
using System.Linq;

namespace Commons
{
    public static class EnumerableExtensions
    {
        private const string MinMaxExceptionMessage = "Sequence contains no elements";

        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            
            return !source.Any();
        }
        
        // ReSharper disable PossibleMultipleEnumeration
        public static T Random<T>(this IEnumerable<T> source, Random random)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (random == null) throw new ArgumentNullException(nameof(random));

            var index = random.Next(source.Count());
            return source.ElementAt(index);
        }
        // ReSharper restore PossibleMultipleEnumeration
        
        // ReSharper disable PossibleMultipleEnumeration
        public static IEnumerable<(T Element1, T Element2)> GetAllPairs<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            
            return source.SelectMany((_, i) => source.Where((_, j) => i < j), (x, y) => (x, y));
        }
        // ReSharper restore PossibleMultipleEnumeration
        
        public static IEnumerable<(TOne Element1, TTwo Element2)> GetAllPairs<TOne, TTwo>(this IEnumerable<TOne> source, IEnumerable<TTwo> target)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (target == null) throw new ArgumentNullException(nameof(target));
            
            return source.SelectMany(s => target.Select(t => (s, t)));
        }
        
        // ReSharper disable PossibleMultipleEnumeration
        public static IEnumerable<(T Element1, T Element2)> GetPairs<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            
            return source.Skip(1).Zip(source, (second, first) => (first, second));
        }
        // ReSharper restore PossibleMultipleEnumeration

        public static TSource MinObjectBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            
            var comparer = Comparer<TKey>.Default;
            using var sourceIterator = source.GetEnumerator();
            if (!sourceIterator.MoveNext())
            {
                throw new InvalidOperationException(MinMaxExceptionMessage);
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

        public static IEnumerable<TSource> MinObjectsBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            
            var comparer = Comparer<TKey>.Default;
            using var sourceIterator = source.GetEnumerator();
            if (!sourceIterator.MoveNext())
            {
                throw new InvalidOperationException(MinMaxExceptionMessage);
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

        public static TSource MaxObjectBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            
            var comparer = Comparer<TKey>.Default;
            using var sourceIterator = source.GetEnumerator();
            if (!sourceIterator.MoveNext())
            {
                throw new InvalidOperationException(MinMaxExceptionMessage);
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

        public static IEnumerable<TSource> MaxObjectsBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            
            var comparer = Comparer<TKey>.Default;
            using var sourceIterator = source.GetEnumerator();
            if (!sourceIterator.MoveNext())
            {
                throw new InvalidOperationException(MinMaxExceptionMessage);
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
            if (source == null) throw new ArgumentNullException(nameof(source));
            
            return source.Where(elem => !Equals(elem, default(T)));
        }
        
        public static IEnumerable<T> OfTypeName<T>(this IEnumerable<T> source, string typeName)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (typeName == null) throw new ArgumentNullException(nameof(typeName));
            
            return source.Where(elem => elem is not null && elem.GetType().Name.Equals(typeName));
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (action == null) throw new ArgumentNullException(nameof(action));
            
            foreach (var item in source) action(item);
        }
        
        public static void ForEachIndex<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (action == null) throw new ArgumentNullException(nameof(action));
            
            var index = 0;
            foreach (var item in source) action(item, index++);
        }
        
        public static int IndexOf<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            
            return source.Select((item, index) => new { Item = item, Index = index })
                .First(el => predicate(el.Item))
                .Index;
        }
        
        public static IEnumerable<int> IndicesOf<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            
            return source.Select((item, index) => new { Item = item, Index = index })
                .Where(el => predicate(el.Item))
                .Select(el => el.Index);
        }

        public static IEnumerable<int> IndicesOf<T>(this IEnumerable<T> source, T value)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return IndicesOfInternal(source, value);
        }
        
        public static IEnumerable<int> IndicesOf<T>(this IEnumerable<T> source, List<T> values)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (values == null) throw new ArgumentNullException(nameof(values));

            return IndicesOfInternal(source, values);
        }
        
        private static IEnumerable<int> IndicesOfInternal<T>(this IEnumerable<T> source, T value)
        {
            var index = 0;
            foreach (var item in source)
            {
                if (Equals(item, value)) yield return index;
                index++;
            }
        }
        
        private static IEnumerable<int> IndicesOfInternal<T>(this IEnumerable<T> source, List<T> values)
        {
            var index = 0;
            foreach (var item in source)
            {
                if (values.Contains(item)) yield return index;
                index++;
            }
        }
        
        // ReSharper disable PossibleMultipleEnumeration
        public static bool EqualsTo<T>(this IEnumerable<T> source1, IEnumerable<T> source2)
        {
            if (source1 == null) throw new ArgumentNullException(nameof(source1));
            if (source2 == null) throw new ArgumentNullException(nameof(source2));
            
            var firstNotSecond = source1.Except(source2);
            var secondNotFirst = source2.Except(source1);
            return source1.Count() == source2.Count() && !firstNotSecond.Any() && !secondNotFirst.Any();
        }
        // ReSharper restore PossibleMultipleEnumeration

        // ReSharper disable PossibleMultipleEnumeration
        public static bool EqualsToOrdered<T>(this IEnumerable<T> source1, IEnumerable<T> source2)
        {
            if (source1 == null) throw new ArgumentNullException(nameof(source1));
            if (source2 == null) throw new ArgumentNullException(nameof(source2));
            
            return source1.Count() == source2.Count() && source1.Intersect(source2).SequenceEqual(source2);
        }
        // ReSharper restore PossibleMultipleEnumeration
        
        public static IEnumerable<T> GetRange<T>(this IEnumerable<T> source, int index, int count)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            
            return source.Skip(index).Take(count);
        }
    }
}
