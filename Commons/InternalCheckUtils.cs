using System;

namespace Commons
{
	internal static class InternalCheckUtils
	{
		internal static void IsNotNull(object value, string parameterName)
		{
			if (value == null) throw new ArgumentNullException(parameterName);
		}
		
		internal static void IsPositiveValue(float value, string parameterName)
		{
			var exceptionMessage = $"'{parameterName}' parameter must be positive";
			if (float.IsNegative(value)) throw new ArithmeticException(exceptionMessage);
		}
		
		internal static void IsLessValueOrEqual(float value1, float value2, string parameterName1, string parameterName2)
		{
			var exceptionMessage = $"'{parameterName1}' parameter must be less or equal than '{parameterName2}' parameter";
			if (value1 > value2) throw new ArithmeticException(exceptionMessage);
		}
		
		internal static void IsFiniteValue(float value, string parameterName)
		{
			var exceptionMessage = $"'{parameterName}' parameter must be finite";
			if (!float.IsFinite(value)) throw new ArithmeticException(exceptionMessage);
		}
	}
}