using Commons.Collections;

namespace Commons.Tests;

public class DictionaryExtensionsTests
{
	[Test]
	public void AddToListValue_ListExistsByKey_AddValue()
	{
		var dict = new Dictionary<int, List<int>>
		{
			{ 1, [1, 2, 3] },
			{ 2, [4, 5, 6] },
			{ 3, [7, 8, 9] }
		};
		
		var expected = new List<int> { 4, 5, 6, 7 };
		dict.AddToListValue(2, 7);
		var actual = dict[2];
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void AddToListValue_ListIsAbsentByKey_CreateListAndValue()
	{
		var dict = new Dictionary<int, List<int>>
		{
			{ 1, [1, 2, 3] },
			{ 3, [7, 8, 9] }
		};
		
		var expected = new List<int> { 4 };
		dict.AddToListValue(2, 4);
		var actual = dict[2];
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void FindKeyByValue_KeyExists_ReturnKey()
	{
		var dict = new Dictionary<int, int>
		{
			{ 1, 10 },
			{ 2, 20 },
			{ 3, 30 }
		};
		
		var actual = dict.FindKeyByValue(20);
		Assert.That(actual, Is.EqualTo(2));
	}
	
	[Test]
	public void FindKeyByValue_ValueIsNull_ReturnKey()
	{
		var dict = new Dictionary<int, int?>
		{
			{ 1, 10 },
			{ 2, null },
			{ 3, 30 }
		};
		
		var actual = dict.FindKeyByValue(null);
		Assert.That(actual, Is.EqualTo(2));
	}
	
	[Test]
	public void FindKeyByValue_KeyIsAbsent_InvalidOperationException()
	{
		var dict = new Dictionary<int, int?>
		{
			{ 1, 10 },
			{ 2, 20 },
			{ 3, 30 }
		};
		
		Assert.Throws<InvalidOperationException>(
			() => dict.FindKeyByValue(40)
		);
	}
}