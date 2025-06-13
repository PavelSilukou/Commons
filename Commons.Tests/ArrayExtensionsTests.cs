using Commons.Collections;

namespace Commons.Tests;

#pragma warning disable CA1806 // Do not ignore method results
public class ArrayExtensionsTests
{
	[Test]
	public void GetRow_NotEmptyArray_ReturnRows()
	{
		var array = new[,]
		{
			{ 1, 2, 3 }, 
			{ 4, 5, 6 },
			{ 7, 8, 9 }
		};
		
		var expected = new[] { 4, 5, 6 };
		var actual = array.GetRow(1);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetRow_EmptyArray_ReturnEmptyRows()
	{
		var array = new int[,] { };
		
		var expected = Array.Empty<int>();
		var actual = array.GetRow(1);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetRow_IndexOutOfRange_IndexOutOfRangeException()
	{
		var array = new[,]
		{
			{ 1, 2, 3 }, 
			{ 4, 5, 6 },
			{ 7, 8, 9 }
		};

		// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
		Assert.Throws<IndexOutOfRangeException>(
			() => array.GetRow(3).ToArray()
		);
	}
	
	[Test]
	public void GetColumn_NotEmptyArray_ReturnColumns()
	{
		var array = new[,]
		{
			{ 1, 2, 3 }, 
			{ 4, 5, 6 },
			{ 7, 8, 9 }
		};
		
		var expected = new[] { 2, 5, 8 };
		var actual = array.GetColumn(1);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetColumn_EmptyArray_ReturnEmptyColumns()
	{
		var array = new int[,] { };
		
		var expected = Array.Empty<int>();
		var actual = array.GetColumn(1);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetColumn_IndexOutOfRange_IndexOutOfRangeException()
	{
		var array = new[,]
		{
			{ 1, 2, 3 }, 
			{ 4, 5, 6 },
			{ 7, 8, 9 }
		};

		// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
		Assert.Throws<IndexOutOfRangeException>(
			() => array.GetColumn(3).ToArray()
		);
	}
	
	[Test]
	public void GetColumnJaggedArray_NotEmptyArray_ReturnColumns()
	{
		var array = new int[][]
		{
			[1, 2],
			[3, 4, 5, 6],
			[7, 8, 9]
		};
		
		var expected = new[] { 2, 4, 8 };
		var actual = array.GetColumn(1);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetColumnJaggedArray_EmptyArray_ReturnEmptyColumns()
	{
		var array = Array.Empty<int[]>();
		
		var expected = Array.Empty<int>();
		var actual = array.GetColumn(1);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetColumnJaggedArray_IndexOutOfRange_IndexOutOfRangeException()
	{
		var array = new int[][]
		{
			[1, 2],
			[3, 4, 5, 6],
			[7, 8, 9]
		};

		// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
		Assert.Throws<IndexOutOfRangeException>(
			() => array.GetColumn(3).ToArray()
		);
	}
}
#pragma warning restore CA1806