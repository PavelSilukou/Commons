using System.Numerics;
using Commons.Collections;

namespace Commons.Tests.Intersection.D2;

#pragma warning disable S107 // Methods should not have too many parameters
// ReSharper disable InconsistentNaming
// ReSharper disable PossibleMultipleEnumeration
public partial class Intersection2DUtilsTests
{
	// I quadrant (abscissa +, ordinate +)
	// II quadrant (abscissa -, ordinate +)
	// III quadrant (abscissa -, ordinate -)
	// IV quadrant (abscissa +, ordinate −)
	
	private static float MoveToQuadrantIAndIV(float value, float moveValue)
	{
		return value + moveValue;
	}
	
	private static float MoveToQuadrantIIAndIII(float value, float moveValue)
	{
		return value - moveValue;
	}
	
	private static Vector2 MoveToQuadrantI(Vector2 value, float moveValue)
	{
		return value with { Y = MoveToQuadrantIAndIV(value.Y, moveValue) };
	}
	
	private static Vector2 MoveToQuadrantII(Vector2 value, float moveValue)
	{
		return value with { X = MoveToQuadrantIIAndIII(value.X, moveValue) };
	}
	
	private static Vector2 MoveToQuadrantIII(Vector2 value, float moveValue)
	{
		return value with { Y = MoveToQuadrantIIAndIII(value.Y, moveValue) };
	}
	
	private static Vector2 MoveToQuadrantIV(Vector2 value, float moveValue)
	{
		return value with { X = MoveToQuadrantIAndIV(value.X, moveValue) };
	}
	
	private static IEnumerable<float> MovesToQuadrantIAndIV(float value, int moves, float moveValue)
	{
		for (var i = 1; i < moves; i++)
		{
			yield return MoveToQuadrantIAndIV(value, moveValue * i);
		}
	}
	
	private static IEnumerable<float> MovesToQuadrantIIAndIII(float value, int moves, float moveValue)
	{
		for (var i = 1; i < moves; i++)
		{
			yield return MoveToQuadrantIIAndIII(value, moveValue * i);
		}
	}
	
	private static IEnumerable<Vector2> MovesToQuadrantI(Vector2 value, int moves, float moveValue)
	{
		for (var i = 1; i < moves; i++)
		{
			yield return MoveToQuadrantI(value, moveValue * i);
		}
	}
	
	private static IEnumerable<Vector2> MovesToQuadrantII(Vector2 value, int moves, float moveValue)
	{
		for (var i = 1; i < moves; i++)
		{
			yield return MoveToQuadrantII(value, moveValue * i);
		}
	}
	
	private static IEnumerable<Vector2> MovesToQuadrantIII(Vector2 value, int moves, float moveValue)
	{
		for (var i = 1; i < moves; i++)
		{
			yield return MoveToQuadrantIII(value, moveValue * i);
		}
	}
	
	private static IEnumerable<Vector2> MovesToQuadrantIV(Vector2 value, int moves, float moveValue)
	{
		for (var i = 1; i < moves; i++)
		{
			yield return MoveToQuadrantIV(value, moveValue * i);
		}
	}
	
	private static IEnumerable<Vector2[]> MovesToQuadrantI(Vector2[] values, int moves, float moveValue)
	{
		var newValues = new Vector2[values.Length][];
		for (var i = 0; i < values.Length; i++)
		{
			newValues[i] = MovesToQuadrantI(values[i], moves, moveValue).ToArray();
		}

		for (var i = 0; i < moves - 1; i++)
		{
			yield return newValues.GetColumn(i).ToArray();
		}
	}
	
	private static IEnumerable<Vector2[]> MovesToQuadrantII(Vector2[] values, int moves, float moveValue)
	{
		var newValues = new Vector2[values.Length][];
		for (var i = 0; i < values.Length; i++)
		{
			newValues[i] = MovesToQuadrantII(values[i], moves, moveValue).ToArray();
		}

		for (var i = 0; i < moves - 1; i++)
		{
			yield return newValues.GetColumn(i).ToArray();
		}
	}
	
	private static IEnumerable<Vector2[]> MovesToQuadrantIII(Vector2[] values, int moves, float moveValue)
	{
		var newValues = new Vector2[values.Length][];
		for (var i = 0; i < values.Length; i++)
		{
			newValues[i] = MovesToQuadrantIII(values[i], moves, moveValue).ToArray();
		}

		for (var i = 0; i < moves - 1; i++)
		{
			yield return newValues.GetColumn(i).ToArray();
		}
	}
	
	private static IEnumerable<Vector2[]> MovesToQuadrantIV(Vector2[] values, int moves, float moveValue)
	{
		var newValues = new Vector2[values.Length][];
		for (var i = 0; i < values.Length; i++)
		{
			newValues[i] = MovesToQuadrantIV(values[i], moves, moveValue).ToArray();
		}

		for (var i = 0; i < moves - 1; i++)
		{
			yield return newValues.GetColumn(i).ToArray();
		}
	}
	
	private static IEnumerable<(float[], float[])> MoveToQuadrantI((float[], float[]) rects, int steps, float stepValue)
	{
		for (var i = 1; i < steps; i++)
		{
			var rect1 = new[] { rects.Item1[0], rects.Item1[1] + stepValue * i, rects.Item1[2], rects.Item1[3] + stepValue * i };
			var rect2 = new[] { rects.Item2[0], rects.Item2[1] + stepValue * i, rects.Item2[2], rects.Item2[3] + stepValue * i };
			yield return new ValueTuple<float[], float[]>(rect1, rect2);
		}
	}
	
	private static IEnumerable<(float[], float[])> MoveToQuadrantII((float[], float[]) rects, int steps, float stepValue)
	{
		for (var i = 1; i < steps; i++)
		{
			var rect1 = new[] { rects.Item1[0] - stepValue * i, rects.Item1[1], rects.Item1[2] - stepValue * i, rects.Item1[3] };
			var rect2 = new[] { rects.Item2[0] - stepValue * i, rects.Item2[1], rects.Item2[2] - stepValue * i, rects.Item2[3] };
			yield return new ValueTuple<float[], float[]>(rect1, rect2);
		}
	}
	
	private static IEnumerable<(float[], float[])> MoveToQuadrantIII((float[], float[]) rects, int steps, float stepValue)
	{
		for (var i = 1; i < steps; i++)
		{
			var rect1 = new[] { rects.Item1[0], rects.Item1[1] - stepValue * i, rects.Item1[2], rects.Item1[3] - stepValue * i };
			var rect2 = new[] { rects.Item2[0], rects.Item2[1] - stepValue * i, rects.Item2[2], rects.Item2[3] - stepValue * i };
			yield return new ValueTuple<float[], float[]>(rect1, rect2);
		}
	}
	
	private static IEnumerable<(float[], float[])> MoveToQuadrantIV((float[], float[]) rects, int steps, float stepValue)
	{
		for (var i = 1; i < steps; i++)
		{
			var rect1 = new[] { rects.Item1[0] + stepValue * i, rects.Item1[1], rects.Item1[2] + stepValue * i, rects.Item1[3] };
			var rect2 = new[] { rects.Item2[0] + stepValue * i, rects.Item2[1], rects.Item2[2] + stepValue * i, rects.Item2[3] };
			yield return new ValueTuple<float[], float[]>(rect1, rect2);
		}
	}
	
	private static IEnumerable<(float[], float[])> MoveToAllQuadrants(
		(float[], float[]) rects,
		int stepsToQuadrantII,
		float stepValueToQuadrantII,
		int stepsToQuadrantIII,
		float stepValueToQuadrantIII,
		int stepsToQuadrantIV,
		float stepValueToQuadrantIV,
		int stepsToQuadrantI,
		float stepValueToQuadrantI
	)
	{
		var moves = MoveToQuadrantII(rects, stepsToQuadrantII, stepValueToQuadrantII);
		foreach (var move in moves)
		{
			yield return move;
		}
		moves = MoveToQuadrantIII(moves.Last(), stepsToQuadrantIII, stepValueToQuadrantIII);
		foreach (var move in moves)
		{
			yield return move;
		}
		moves = MoveToQuadrantIV(moves.Last(), stepsToQuadrantIV, stepValueToQuadrantIV);
		foreach (var move in moves)
		{
			yield return move;
		}
		moves = MoveToQuadrantI(moves.Last(), stepsToQuadrantI, stepValueToQuadrantI);
		foreach (var move in moves)
		{
			yield return move;
		}
	}
}