namespace Commons.Tests;

#pragma warning disable CA1861 // Avoid constant arrays as arguments
#pragma warning disable CA1707 // Identifiers should not contain underscores
public class ReadOnlyCollectionExtensionsTests
{
	[Test]
	public void IsEmpty_NotEmptyEnumerable_ReturnFalse()
	{
		var enumerable = new[] { 1, 2, 3, 4, 5 };
		var actual = enumerable.IsEmpty();
		Assert.That(actual, Is.False);
	}

	[Test]
	public void IsEmpty_EmptyEnumerable_ReturnTrue()
	{
		var enumerable = Array.Empty<int>();
		var actual = enumerable.IsEmpty();
		Assert.That(actual, Is.True);
	}
	
	[Test]
	public void Random_NotEmptyEnumerable_ReturnValue()
	{
		var enumerable = new[] { 1, 2, 3, 4, 5 };
		var actual = enumerable.Random(new Random());
		CollectionAssert.Contains(enumerable, actual);
	}
	
	[Test]
	public void Random_EmptyEnumerable_ArgumentOutOfRangeException()
	{
		var enumerable = Array.Empty<int>();
		
		Assert.Throws<ArgumentOutOfRangeException>(
			() => enumerable.Random(new Random())
		);
	}
	
	[Test]
	public void GetAllPairs_NotEmptyEnumerable_ReturnPairs()
	{
		var enumerable = new[] { 1, 2, 3 };
		var expected = new[]
		{
			(1, 2),
			(1, 3),
			(2, 3)
		};
		var actual = enumerable.GetAllPairs();
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetAllPairs_EmptyEnumerable_ReturnEmpty()
	{
		var enumerable = Array.Empty<int>();
		var expected = Array.Empty<int>();
		var actual = enumerable.GetAllPairs();
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetAllPairs_NotEmptyEnumerables_ReturnPairs()
	{
		var enumerable1 = new[] { 1, 2, 3 };
		var enumerable2 = new[] { 5, 6, 7 };
		var expected = new[]
		{
			(1, 5),
			(1, 6),
			(1, 7),
			(2, 5),
			(2, 6),
			(2, 7),
			(3, 5),
			(3, 6),
			(3, 7)
		};
		var actual = enumerable1.GetAllPairs(enumerable2);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetAllPairs_EmptyEnumerable1AndNotEmptyEnumerable2_ReturnEmpty()
	{
		var enumerable1 = Array.Empty<int>();
		var enumerable2 = new[] { 3, 4 };
		var expected = Array.Empty<int>();
		var actual = enumerable1.GetAllPairs(enumerable2);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetAllPairs_NotEmptyEnumerable1AndEmptyEnumerable2_ReturnEmpty()
	{
		var enumerable1 = new[] { 1, 2 };
		var enumerable2 = Array.Empty<int>();
		var expected = Array.Empty<int>();
		var actual = enumerable1.GetAllPairs(enumerable2);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetAllPairs_EmptyEnumerables_ReturnEmpty()
	{
		var enumerable1 = Array.Empty<int>();
		var enumerable2 = Array.Empty<int>();
		var expected = Array.Empty<int>();
		var actual = enumerable1.GetAllPairs(enumerable2);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetPairs_NotEmptyEnumerable_ReturnPairs()
	{
		var enumerable = new[] { 1, 2, 3 };
		var expected = new[]
		{
			(1, 2),
			(2, 3)
		};
		var actual = enumerable.GetPairs();
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetPairs_2Elements_ReturnPairs()
	{
		var enumerable = new[] { 1, 2 };
		var expected = new[]
		{
			(1, 2)
		};
		var actual = enumerable.GetPairs();
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetPairs_1Element_ReturnEmpty()
	{
		var enumerable = new[] { 1 };
		var expected = Array.Empty<int>();
		var actual = enumerable.GetPairs();
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetPairs_EmptyEnumerable_ReturnEmpty()
	{
		var enumerable = Array.Empty<int>();
		var expected = Array.Empty<int>();
		var actual = enumerable.GetPairs();
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void MinObjectBy_NotEmptyEnumerable_ReturnObject()
	{
		var obj1 = new SimpleObject(3);
		var obj2 = new SimpleObject(1);
		var obj3 = new SimpleObject(2);
		var enumerable = new[] { obj1, obj2, obj3 };
		var actual = enumerable.MinObjectBy(obj => obj.Id);
		Assert.That(actual, Is.EqualTo(obj2));
	}
	
	[Test]
	public void MinObjectBy_EmptyEnumerable_InvalidOperationException()
	{
		var enumerable = Array.Empty<SimpleObject>();
		
		var exception = Assert.Throws<InvalidOperationException>(
			() => enumerable.MinObjectBy(obj => obj.Id)
		);
		Assert.That(exception.Source, Is.EqualTo("Commons"));
	}
	
	[Test]
	public void MinObjectsBy_NotEmptyEnumerable_ReturnObjects()
	{
		var obj1 = new SimpleObject(3);
		var obj2 = new SimpleObject(1);
		var obj3 = new SimpleObject(1);
		var enumerable = new[] { obj1, obj2, obj3 };
		var expected = new[] { obj2, obj3 };
		var actual = enumerable.MinObjectsBy(obj => obj.Id);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void MinObjectsBy_EmptyEnumerable_InvalidOperationException()
	{
		var enumerable = Array.Empty<SimpleObject>();
		
		var exception = Assert.Throws<InvalidOperationException>(
			() => enumerable.MinObjectsBy(obj => obj.Id)
		);
		Assert.That(exception.Source, Is.EqualTo("Commons"));
	}
	
	[Test]
	public void MaxObjectBy_NotEmptyEnumerable_ReturnObject()
	{
		var obj1 = new SimpleObject(2);
		var obj2 = new SimpleObject(3);
		var obj3 = new SimpleObject(1);
		var enumerable = new[] { obj1, obj2, obj3 };
		var actual = enumerable.MaxObjectBy(obj => obj.Id);
		Assert.That(actual, Is.EqualTo(obj2));
	}
	
	[Test]
	public void MaxObjectBy_EmptyEnumerable_InvalidOperationException()
	{
		var enumerable = Array.Empty<SimpleObject>();
		
		var exception = Assert.Throws<InvalidOperationException>(
			() => enumerable.MaxObjectBy(obj => obj.Id)
		);
		Assert.That(exception.Source, Is.EqualTo("Commons"));
	}
	
	[Test]
	public void MaxObjectsBy_NotEmptyEnumerable_ReturnObjects()
	{
		var obj1 = new SimpleObject(2);
		var obj2 = new SimpleObject(3);
		var obj3 = new SimpleObject(3);
		var enumerable = new[] { obj1, obj2, obj3 };
		var expected = new[] { obj2, obj3 };
		var actual = enumerable.MaxObjectsBy(obj => obj.Id);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void MaxObjectsBy_EmptyEnumerable_InvalidOperationException()
	{
		var enumerable = Array.Empty<SimpleObject>();
		
		var exception = Assert.Throws<InvalidOperationException>(
			() => enumerable.MaxObjectsBy(obj => obj.Id)
		);
		Assert.That(exception.Source, Is.EqualTo("Commons"));
	}
	
	[Test]
	public void ForEach_NotEmptyEnumerable_WorksCorrectly()
	{
		var obj1 = new SimpleObject(1);
		var obj2 = new SimpleObject(2);
		var obj3 = new SimpleObject(3);
		var enumerable = new[] { obj1, obj2, obj3 };
		var expected = new[] { 2, 3, 4 };
		enumerable.ForEach(obj => obj.Id += 1);
		var actual = enumerable.Select(obj => obj.Id);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void ForEach_EmptyEnumerable_WorksCorrectly()
	{
		var enumerable = Array.Empty<SimpleObject>();
		var expected = Array.Empty<SimpleObject>();
		enumerable.ForEach(obj => obj.Id += 1);
		var actual = enumerable.Select(obj => obj.Id);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void ForEachIndex_NotEmptyEnumerable_WorksCorrectly()
	{
		var obj1 = new SimpleObject(1);
		var obj2 = new SimpleObject(2);
		var obj3 = new SimpleObject(3);
		var enumerable = new[] { obj1, obj2, obj3 };
		var expected = new[] { 2, 4, 6 };
		enumerable.ForEachIndex((obj, index) => obj.Id += 1 + index);
		var actual = enumerable.Select(obj => obj.Id);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void ForEachIndex_EmptyEnumerable_WorksCorrectly()
	{
		var enumerable = Array.Empty<SimpleObject>();
		var expected = Array.Empty<SimpleObject>();
		enumerable.ForEachIndex((obj, index) => obj.Id += 1 + index);
		var actual = enumerable.Select(obj => obj.Id);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void SequenceEqualDisorder_Enumerable1EqualEnumerable2Ordered_ReturnTrue()
	{
		var enumerable1 = new[] { 1, 2, 3, 4 };
		var enumerable2 = new[] { 1, 2, 3, 4 };
		var actual = enumerable1.SequenceEqualDisorder(enumerable2);
		Assert.That(actual, Is.True);
	}
	
	[Test]
	public void SequenceEqualDisorder_Enumerable1EqualEnumerable2Disordered_ReturnTrue()
	{
		var enumerable1 = new[] { 1, 2, 3, 4 };
		var enumerable2 = new[] { 4, 3, 2, 1 };
		var actual = enumerable1.SequenceEqualDisorder(enumerable2);
		Assert.That(actual, Is.True);
	}
	
	[Test]
	public void SequenceEqualDisorder_Enumerable1NotEqualEnumerable2_ReturnFalse()
	{
		var enumerable1 = new[] { 1, 2, 3, 4 };
		var enumerable2 = new[] { 1, 2, 3 };
		var actual = enumerable1.SequenceEqualDisorder(enumerable2);
		Assert.That(actual, Is.False);
	}
	
	[Test]
	public void SequenceEqualDisorder_EmptyEnumerables_ReturnTrue()
	{
		var enumerable1 = Array.Empty<int>();
		var enumerable2 = Array.Empty<int>();
		var actual = enumerable1.SequenceEqualDisorder(enumerable2);
		Assert.That(actual, Is.True);
	}
	
	[Test]
	public void SequenceEqual_Enumerable1EqualEnumerable2Ordered_ReturnTrue()
	{
		var enumerable1 = new[] { 1, 2, 3, 4 };
		var enumerable2 = new[] { 1, 2, 3, 4 };
		var actual = enumerable1.SequenceEqual(enumerable2);
		Assert.That(actual, Is.True);
	}
	
	[Test]
	public void SequenceEqual_Enumerable1EqualEnumerable2Disordered_ReturnFalse()
	{
		var enumerable1 = new[] { 1, 2, 3, 4 };
		var enumerable2 = new[] { 4, 3, 2, 1 };
		var actual = enumerable1.SequenceEqual(enumerable2);
		Assert.That(actual, Is.False);
	}
	
	[Test]
	public void SequenceEqual_Enumerable1NotEqualEnumerable2_ReturnFalse()
	{
		var enumerable1 = new[] { 1, 2, 3, 4 };
		var enumerable2 = new[] { 1, 2, 3 };
		var actual = enumerable1.SequenceEqual(enumerable2);
		Assert.That(actual, Is.False);
	}
	
	[Test]
	public void SequenceEqual_EmptyEnumerables_ReturnTrue()
	{
		var enumerable1 = Array.Empty<int>();
		var enumerable2 = Array.Empty<int>();
		var actual = enumerable1.SequenceEqual(enumerable2);
		Assert.That(actual, Is.True);
	}
	
	private class SimpleObject(int id)
	{
		public int Id { get; set; } = id;
	}
}
#pragma warning restore CA1861