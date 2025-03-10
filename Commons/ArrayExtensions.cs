using JetBrains.Annotations;

namespace Commons
{
	[PublicAPI]
	public static class ArrayExtensions
	{
		public static T[] GetRow<T>(this T[,] array, int rowIndex)
		{
			var columnsCount = array.GetLength(1);
			var result = new T[columnsCount];
			for (var columnIndex = 0; columnIndex < columnsCount; columnIndex++)
			{
				result[columnIndex] = array[rowIndex, columnIndex];
			}

			return result;
		}
	}
}