using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Commons
{
	public static class ArrayExtensions
	{
		public static IEnumerable<TSource> GetRow<TSource>(this TSource[,] array, int rowIndex)
		{
			// ReSharper disable once ConvertIfStatementToReturnStatement
			if (array == null) throw new ArgumentNullException(nameof(array));

			return GetRowInternal(array, rowIndex);
		}

		private static IEnumerable<TSource> GetRowInternal<TSource>(this TSource[,] array, int rowIndex)
		{
			var columnsCount = array.GetLength(1);
			for (var columnIndex = 0; columnIndex < columnsCount; columnIndex++)
			{
				yield return array[rowIndex, columnIndex];
			}
		}
		
		public static IEnumerable<TSource> GetColumn<TSource>(this TSource[,] array, int columnIndex)
		{
			// ReSharper disable once ConvertIfStatementToReturnStatement
			if (array == null) throw new ArgumentNullException(nameof(array));

			return GetColumnInternal(array, columnIndex);
		}
		
		public static IEnumerable<TSource> GetColumn<TSource>(this TSource[][] array, int columnIndex)
		{
			// ReSharper disable once ConvertIfStatementToReturnStatement
			if (array == null) throw new ArgumentNullException(nameof(array));

			return GetColumnInternal(array, columnIndex);
		}

		public static ReadOnlyCollection<TSource> AsReadOnly<TSource>(this TSource[] array)
		{
			return Array.AsReadOnly(array);
		}

		private static IEnumerable<TSource> GetColumnInternal<TSource>(this TSource[,] array, int columnIndex)
		{
			var rowsCount = array.GetLength(0);
			for (var rowIndex = 0; rowIndex < rowsCount; rowIndex++)
			{
				yield return array[rowIndex, columnIndex];
			}
		}

		private static IEnumerable<TSource> GetColumnInternal<TSource>(this TSource[][] array, int columnIndex)
		{
			var rowsCount = array.GetLength(0);
			for (var rowIndex = 0; rowIndex < rowsCount; rowIndex++)
			{
				yield return array[rowIndex][columnIndex];
			}
		}
	}
}