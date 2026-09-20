using System;
using System.Collections.Generic;
using System.Linq;

namespace Commons
{
    public static class ReadOnlyCollectionExtensions
    {
        public static bool IsEmpty<TSource>(this IReadOnlyCollection<TSource> source)
        {
            return source.Count == 0;
        }
        
        public static TSource Random<TSource>(this IReadOnlyCollection<TSource> source, Random random)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            
            var index = random.Next(source.Count);
            return source.ElementAt(index);
        }
        
        public static IEnumerable<(TSource Element1, TSource Element2)> GetAllPairs<TSource>(this IReadOnlyCollection<TSource> source)
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.SelectMany((_, i) => source.Where((_, j) => i < j), (x, y) => (x, y));
        }
        
        public static IEnumerable<(TOne Element1, TTwo Element2)> GetAllPairs<TOne, TTwo>(this IReadOnlyCollection<TOne> source, IReadOnlyCollection<TTwo> target)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (target == null) throw new ArgumentNullException(nameof(target));

            return source.SelectMany(s => target.Select(t => (s, t)));
        }
        
        public static IEnumerable<(TSource Element1, TSource Element2)> GetPairs<TSource>(this IReadOnlyCollection<TSource> source)
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.Skip(1).Zip(source, (second, first) => (first, second));
        }
        
        public static TSource MinObjectBy<TSource, TKey>(
            this IReadOnlyCollection<TSource> source,
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
            this IReadOnlyCollection<TSource> source,
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
            this IReadOnlyCollection<TSource> source,
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
            this IReadOnlyCollection<TSource> source,
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
        
        public static void ForEach<TSource>(this IReadOnlyCollection<TSource> source, Action<TSource> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (action == null) throw new ArgumentNullException(nameof(action));

            foreach (var item in source) action(item);
        }
        
        public static void ForEachIndex<TSource>(this IReadOnlyCollection<TSource> source, Action<TSource, int> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (action == null) throw new ArgumentNullException(nameof(action));

            var index = 0;
            foreach (var item in source) action(item, index++);
        }
        
        public static bool SequenceEqualDisorder<TSource>(this IReadOnlyCollection<TSource> source1, IReadOnlyCollection<TSource> source2)
        {
            if (source1 == null) throw new ArgumentNullException(nameof(source1));
            if (source2 == null) throw new ArgumentNullException(nameof(source2));

            if (source1.Count != source2.Count) return false;
            return !source1.Except(source2).Any() && !source2.Except(source1).Any();
        }
        
        public static bool AllEquals<TSource>(this IReadOnlyCollection<TSource> source, IEqualityComparer<TSource>? equalityComparer = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            equalityComparer ??= EqualityComparer<TSource>.Default;
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
    }
}