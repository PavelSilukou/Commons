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
    // TODO: check all docs
    /// <summary>
    /// Provides extension methods for <see cref="IEnumerable{T}"/> operations.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Determines whether the specified enumerable sequence is empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The enumerable sequence to check.</param>
        /// <returns>
        /// <c>true</c> if the sequence is empty; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is <c>null</c>.</exception>
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return !source.Any();
        }
        
        /// <summary>
        /// Returns a random element from the enumerable sequence.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The enumerable sequence to select from.</param>
        /// <param name="random">The random number generator to use for selection.</param>
        /// <returns>A random element from the sequence.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="random"/> is <c>null</c>.</exception>
        // ReSharper disable PossibleMultipleEnumeration
        public static T Random<T>(this IEnumerable<T> source, Random random)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (random == null) throw new ArgumentNullException(nameof(random));

            var index = random.Next(source.Count());
            return source.ElementAt(index);
        }
        // ReSharper restore PossibleMultipleEnumeration
        
        /// <summary>
        /// Returns all unique pairs of elements from the sequence where the first element comes before the second.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The enumerable sequence to create pairs from.</param>
        /// <returns>An enumerable of tuples containing all pairs (element1, element2) where element1 appears before element2 in the source sequence.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is <c>null</c>.</exception>
        // ReSharper disable PossibleMultipleEnumeration
        public static IEnumerable<(T Element1, T Element2)> GetAllPairs<T>(this IEnumerable<T> source)
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.SelectMany((_, i) => source.Where((_, j) => i < j), (x, y) => (x, y));
        }
        // ReSharper restore PossibleMultipleEnumeration
        
        /// <summary>
        /// Returns all pairs of elements where the first element is from the source sequence and the second is from the target sequence.
        /// </summary>
        /// <typeparam name="TOne">The type of elements in the source sequence.</typeparam>
        /// <typeparam name="TTwo">The type of elements in the target sequence.</typeparam>
        /// <param name="source">The enumerable sequence for the first element of each pair.</param>
        /// <param name="target">The enumerable sequence for the second element of each pair.</param>
        /// <returns>An enumerable of tuples containing all pairs (sourceElement, targetElement).</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="target"/> is <c>null</c>.</exception>
        public static IEnumerable<(TOne Element1, TTwo Element2)> GetAllPairs<TOne, TTwo>(this IEnumerable<TOne> source, IEnumerable<TTwo> target)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (target == null) throw new ArgumentNullException(nameof(target));

            return source.SelectMany(s => target.Select(t => (s, t)));
        }
        
        /// <summary>
        /// Returns pairs of consecutive elements from the sequence.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The enumerable sequence to create consecutive pairs from.</param>
        /// <returns>An enumerable of tuples containing consecutive pairs (element[i], element[i+1]).</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is <c>null</c>.</exception>
        // ReSharper disable PossibleMultipleEnumeration
        public static IEnumerable<(T Element1, T Element2)> GetPairs<T>(this IEnumerable<T> source)
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.Skip(1).Zip(source, (second, first) => (first, second));
        }
        // ReSharper restore PossibleMultipleEnumeration

        /// <summary>
        /// Returns the element that has the minimum value when applying the specified selector function.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by the selector function.</typeparam>
        /// <param name="source">The enumerable sequence to search.</param>
        /// <param name="selector">A function to extract a comparable key from each element.</param>
        /// <param name="comparer">An optional <see cref="IComparer{TKey}"/> to compare keys. If <c>null</c>, uses the default comparer.</param>
        /// <returns>The element with the minimum key value.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="selector"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
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

        /// <summary>
        /// Returns all elements that have the minimum value when applying the specified selector function.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by the selector function.</typeparam>
        /// <param name="source">The enumerable sequence to search.</param>
        /// <param name="selector">A function to extract a comparable key from each element.</param>
        /// <param name="comparer">An optional <see cref="IComparer{TKey}"/> to compare keys. If <c>null</c>, uses the default comparer.</param>
        /// <returns>An enumerable containing all elements with the minimum key value.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="selector"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
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

        /// <summary>
        /// Returns the element that has the maximum value when applying the specified selector function.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by the selector function.</typeparam>
        /// <param name="source">The enumerable sequence to search.</param>
        /// <param name="selector">A function to extract a comparable key from each element.</param>
        /// <param name="comparer">An optional <see cref="IComparer{TKey}"/> to compare keys. If <c>null</c>, uses the default comparer.</param>
        /// <returns>The element with the maximum key value.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="selector"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
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

        /// <summary>
        /// Returns all elements that have the maximum value when applying the specified selector function.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by the selector function.</typeparam>
        /// <param name="source">The enumerable sequence to search.</param>
        /// <param name="selector">A function to extract a comparable key from each element.</param>
        /// <param name="comparer">An optional <see cref="IComparer{TKey}"/> to compare keys. If <c>null</c>, uses the default comparer.</param>
        /// <returns>An enumerable containing all elements with the maximum key value.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="selector"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
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
        
        /// <summary>
        /// Filters out null or default values from the enumerable sequence.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The enumerable sequence to filter.</param>
        /// <returns>An enumerable containing only non-null, non-default elements from the source sequence.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is <c>null</c>.</exception>
        public static IEnumerable<T> ClearNull<T>(this IEnumerable<T> source)
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.Where(elem => !Equals(elem, default(T)));
        }
        
        /// <summary>
        /// Filters the enumerable sequence to include only elements whose type name matches the specified string.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The enumerable sequence to filter.</param>
        /// <param name="typeName">The type name to match against.</param>
        /// <returns>An enumerable containing only non-null elements whose type name matches the specified string.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="typeName"/> is <c>null</c>.</exception>
        public static IEnumerable<T> OfTypeName<T>(this IEnumerable<T> source, string typeName)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (typeName == null) throw new ArgumentNullException(nameof(typeName));

            return source.Where(elem => elem is not null && elem.GetType().Name.Equals(typeName));
        }

        /// <summary>
        /// Executes an action on each element in the enumerable sequence.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The enumerable sequence to iterate through.</param>
        /// <param name="action">The action to perform on each element.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="action"/> is <c>null</c>.</exception>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (action == null) throw new ArgumentNullException(nameof(action));

            foreach (var item in source) action(item);
        }
        
        /// <summary>
        /// Executes an action on each element in the enumerable sequence, providing the element and its index.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The enumerable sequence to iterate through.</param>
        /// <param name="action">The action to perform on each element, receiving the element and its index.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="action"/> is <c>null</c>.</exception>
        public static void ForEachIndex<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (action == null) throw new ArgumentNullException(nameof(action));

            var index = 0;
            foreach (var item in source) action(item, index++);
        }
        
        /// <summary>
        /// Returns the index of the first element that satisfies the specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The enumerable sequence to search.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>The zero-based index of the first element that satisfies the predicate.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="predicate"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown when no element satisfies the predicate.</exception>
        public static int IndexOf<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return source.Select((item, index) => (item, index))
                .First(x => predicate(x.item))
                .index;
        }
        
        /// <summary>
        /// Returns the indices of all elements that satisfy the specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The enumerable sequence to search.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>An enumerable of zero-based indices of elements that satisfy the predicate.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="predicate"/> is <c>null</c>.</exception>
        public static IEnumerable<int> IndicesOf<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return source.Select((item, index) => (item, index))
                .Where(x => predicate(x.item))
                .Select(x => x.index);
        }

        /// <summary>
        /// Returns the indices of all elements that match the specified value.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The enumerable sequence to search.</param>
        /// <param name="value">The value to match against.</param>
        /// <returns>An enumerable of zero-based indices of elements that equal the specified value.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is <c>null</c>.</exception>
        public static IEnumerable<int> IndicesOf<T>(this IEnumerable<T> source, T value)
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (source == null) throw new ArgumentNullException(nameof(source));

            return IndicesOfInternal(source, value);
        }
        
        /// <summary>
        /// Returns the indices of all elements that match any value in the specified list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The enumerable sequence to search.</param>
        /// <param name="values">The list of values to match against.</param>
        /// <returns>An enumerable of zero-based indices of elements that match any value in the specified list.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="values"/> is <c>null</c>.</exception>
        public static IEnumerable<int> IndicesOf<T>(this IEnumerable<T> source, List<T> values)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (values == null) throw new ArgumentNullException(nameof(values));

            return IndicesOfInternal(source, values);
        }

        private static IEnumerable<int> IndicesOfInternal<T>(IEnumerable<T> source, T value)
        {
            var index = 0;
            foreach (var item in source)
            {
                if (Equals(item, value)) yield return index;
                index++;
            }
        }

        private static IEnumerable<int> IndicesOfInternal<T>(IEnumerable<T> source, List<T> values)
        {
            var index = 0;
            foreach (var item in source)
            {
                if (values.Contains(item)) yield return index;
                index++;
            }
        }
        
        /// <summary>
        /// Determines whether two sequences are equal regardless of the order of their elements.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequences.</typeparam>
        /// <param name="source1">The first enumerable sequence.</param>
        /// <param name="source2">The second enumerable sequence.</param>
        /// <returns>
        /// <c>true</c> if both sequences contain the same elements (regardless of order); otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source1"/> or <paramref name="source2"/> is <c>null</c>.</exception>
        // ReSharper disable PossibleMultipleEnumeration
        public static bool SequenceEqualDisorder<T>(this IEnumerable<T> source1, IEnumerable<T> source2)
        {
            if (source1 == null) throw new ArgumentNullException(nameof(source1));
            if (source2 == null) throw new ArgumentNullException(nameof(source2));

            if (source1.Count() != source2.Count()) return false;
            return !source1.Except(source2).Any() && !source2.Except(source1).Any();
        }
        // ReSharper restore PossibleMultipleEnumeration
        
        /// <summary>
        /// Returns a specified number of contiguous elements from a sequence, starting at a specified index.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The enumerable sequence.</param>
        /// <param name="index">The zero-based starting index.</param>
        /// <param name="count">The number of elements to return.</param>
        /// <returns>An enumerable containing <paramref name="count"/> elements starting from <paramref name="index"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is <c>null</c>.</exception>
        public static IEnumerable<T> GetRange<T>(this IEnumerable<T> source, int index, int count)
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.Skip(index).Take(count);
        }
        
        /// <summary>
        /// Determines whether all elements in the sequence are equal to each other.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The enumerable sequence to check.</param>
        /// <param name="equalityComparer">An optional <see cref="IEqualityComparer{T}"/> to compare elements. If <c>null</c>, uses the default comparer.</param>
        /// <returns>
        /// <c>true</c> if all elements in the sequence are equal; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
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

        /// <summary>
        /// Returns an enumerable of intermediate results of applying a function to each element in sequence with an accumulator.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence and the accumulator.</typeparam>
        /// <param name="source">The enumerable sequence to aggregate.</param>
        /// <param name="func">A function to apply to the accumulator and each element, returning a new accumulator value.</param>
        /// <param name="seed">An optional initial value for the accumulator. Defaults to <c>default(T)</c>.</param>
        /// <returns>An enumerable containing the accumulator value after each element is processed.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="func"/> is <c>null</c>.</exception>
        [PublicAPI]
        public static IEnumerable<T> AggregateIntermediate<T>(this IEnumerable<T> source, Func<T, T, T> func, T? seed = default)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (seed == null) throw new ArgumentNullException(nameof(seed));

            foreach (var item in source)
            {
                seed = func(seed, item);
                yield return seed;
            }
        }

        /// <summary>
        /// Converts the enumerable sequence to a read-only collection backed by an array.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The enumerable sequence to convert.</param>
        /// <returns>A <see cref="ReadOnlyCollection{T}"/> wrapper around an array containing all elements from the source sequence.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is <c>null</c>.</exception>
        public static ReadOnlyCollection<T> ToReadOnlyArray<T>(this IEnumerable<T> source)
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (source == null) throw new ArgumentNullException(nameof(source));

            return Array.AsReadOnly(source.ToArray());
        }
    }
}