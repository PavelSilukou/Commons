using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;

namespace Commons
{
    // TODO: rename T to TSource
    // TODO: add checking if enumerable is collection/array/list
    // TODO: fix PossibleMultipleEnumeration
    public static class EnumerableExtensions
    {
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
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (source == null) throw new ArgumentNullException(nameof(source));
            
            return source.SelectMany((_, i) => source.Where((_, j) => i < j), (x, y) => (x, y));
        }
        // ReSharper restore PossibleMultipleEnumeration
        
        public static IEnumerable<(TOne Element1, TTwo Element2)> GetAllPairs<TOne, TTwo>(this IEnumerable<TOne> source, IEnumerable<TTwo> target)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (target == null) throw new ArgumentNullException(nameof(target));
            
            return source.SelectMany(s => target.Select(t => (s, t)));
        }
        
        // ReSharper disable PossibleMultipleEnumeration
        public static IEnumerable<(T Element1, T Element2)> GetPairs<T>(this IEnumerable<T> source)
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (source == null) throw new ArgumentNullException(nameof(source));
            
            return source.Skip(1).Zip(source, (second, first) => (first, second));
        }
        // ReSharper restore PossibleMultipleEnumeration

        public static TSource MinObjectBy<TSource, TKey>(
            this IEnumerable<TSource> source, 
            Func<TSource, TKey> selector,
            IComparer<TKey>? comparer = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            
            comparer ??= Comparer<TKey>.Default;
            using var sourceIterator = source.GetEnumerator();
            if (!sourceIterator.MoveNext())
            {
                throw new InvalidOperationException($"'{nameof(source)}' is empty.");
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

        public static IEnumerable<TSource> MinObjectsBy<TSource, TKey>(
            this IEnumerable<TSource> source, 
            Func<TSource, TKey> selector,
            IComparer<TKey>? comparer = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            
            comparer ??= Comparer<TKey>.Default;
            using var sourceIterator = source.GetEnumerator();
            if (!sourceIterator.MoveNext())
            {
                throw new InvalidOperationException($"'{nameof(source)}' is empty.");
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

        public static TSource MaxObjectBy<TSource, TKey>(
            this IEnumerable<TSource> source, 
            Func<TSource, TKey> selector,
            IComparer<TKey>? comparer = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            
            comparer ??= Comparer<TKey>.Default;
            using var sourceIterator = source.GetEnumerator();
            if (!sourceIterator.MoveNext())
            {
                throw new InvalidOperationException($"'{nameof(source)}' is empty.");
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

        public static IEnumerable<TSource> MaxObjectsBy<TSource, TKey>(
            this IEnumerable<TSource> source, 
            Func<TSource, TKey> selector,
            IComparer<TKey>? comparer = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            
            comparer ??= Comparer<TKey>.Default;
            using var sourceIterator = source.GetEnumerator();
            if (!sourceIterator.MoveNext())
            {
                throw new InvalidOperationException($"'{nameof(source)}' is empty.");
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
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (source == null) throw new ArgumentNullException(nameof(source));
            
            return source.Where(elem => !Equals(elem, default(T)));
        }
        
        public static IEnumerable<T> OfTypeName<T>(this IEnumerable<T> source, string typeName)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            // ReSharper disable once ConvertIfStatementToReturnStatement
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
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (source == null) throw new ArgumentNullException(nameof(source));

            return IndicesOfInternal(source, value);
        }
        
        public static IEnumerable<int> IndicesOf<T>(this IEnumerable<T> source, List<T> values)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            // ReSharper disable once ConvertIfStatementToReturnStatement
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
        public static bool SequenceEqualDisorder<T>(this IEnumerable<T> source1, IEnumerable<T> source2)
        {
            if (source1 == null) throw new ArgumentNullException(nameof(source1));
            if (source2 == null) throw new ArgumentNullException(nameof(source2));

            if (source1.Count() != source2.Count()) return false;
            var firstNotSecond = source1.Except(source2);
            if (!firstNotSecond.IsEmpty()) return false;
            var secondNotFirst = source2.Except(source1);
            return secondNotFirst.IsEmpty();
        }
        // ReSharper restore PossibleMultipleEnumeration
        
        public static IEnumerable<T> GetRange<T>(this IEnumerable<T> source, int index, int count)
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (source == null) throw new ArgumentNullException(nameof(source));
            
            return source.Skip(index).Take(count);
        }
        
        public static bool AllEquals<T>(this IEnumerable<T> source, IEqualityComparer<T>? equalityComparer = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            equalityComparer ??= EqualityComparer<T>.Default;
            using var sourceIterator = source.GetEnumerator();
            if (!sourceIterator.MoveNext())
            {
                throw new InvalidOperationException($"'{nameof(source)}' is empty.");
            }
            var first = sourceIterator.Current;
            while (sourceIterator.MoveNext())
            {
                if (!equalityComparer.Equals(first, sourceIterator.Current))
                {
                    return false;
                }
            }

            return true;
        }

        [PublicAPI]
        public static IEnumerable<T> AggregateIntermediate<T>(this IEnumerable<T> source, Func<T, T, T> func, T? seed = default)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            
            foreach (var item in source)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                seed = func(seed, item);
#pragma warning restore CS8604 // Possible null reference argument.
                yield return seed;
            }
        }

        public static ReadOnlyCollection<T> ToReadOnlyArray<T>(this IEnumerable<T> source)
        {
            return Array.AsReadOnly(source.ToArray());
        }
    }
}
