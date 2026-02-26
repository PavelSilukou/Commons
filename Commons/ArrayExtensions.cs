using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Commons
{
	public static class ArrayExtensions
	{
		public static IEnumerable<T> GetRow<T>(this T[,] array, int rowIndex)
		{
			// ReSharper disable once ConvertIfStatementToReturnStatement
			if (array == null) throw new ArgumentNullException(nameof(array));

			return GetRowInternal(array, rowIndex);
		}

		private static IEnumerable<T> GetRowInternal<T>(this T[,] array, int rowIndex)
		{
			var columnsCount = array.GetLength(1);
			for (var columnIndex = 0; columnIndex < columnsCount; columnIndex++)
			{
				yield return array[rowIndex, columnIndex];
			}
		}
		
		public static IEnumerable<T> GetColumn<T>(this T[,] array, int columnIndex)
		{
			// ReSharper disable once ConvertIfStatementToReturnStatement
			if (array == null) throw new ArgumentNullException(nameof(array));

			return GetColumnInternal(array, columnIndex);
		}
		
		public static IEnumerable<T> GetColumn<T>(this T[][] array, int columnIndex)
		{
			// ReSharper disable once ConvertIfStatementToReturnStatement
			if (array == null) throw new ArgumentNullException(nameof(array));

			return GetColumnInternal(array, columnIndex);
		}

		public static ReadOnlyCollection<T> AsReadOnly<T>(this T[] array)
		{
			return Array.AsReadOnly(array);
		}

		private static IEnumerable<T> GetColumnInternal<T>(this T[,] array, int columnIndex)
		{
			var rowsCount = array.GetLength(0);
			for (var rowIndex = 0; rowIndex < rowsCount; rowIndex++)
			{
				yield return array[rowIndex, columnIndex];
			}
		}

		private static IEnumerable<T> GetColumnInternal<T>(this T[][] array, int columnIndex)
		{
			var rowsCount = array.GetLength(0);
			for (var rowIndex = 0; rowIndex < rowsCount; rowIndex++)
			{
				yield return array[rowIndex][columnIndex];
			}
		}
	}
}