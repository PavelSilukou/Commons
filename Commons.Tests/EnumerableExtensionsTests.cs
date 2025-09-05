namespace Commons.Tests;

#pragma warning disable CA1861 // Avoid constant arrays as arguments
// ReSharper disable PossibleMultipleEnumeration
public class EnumerableExtensionsTests
{
	[Test]
	public void IsEmpty_NotEmptyEnumerable_ReturnFalse()
	{
		var enumerable = new[] { 1, 2, 3, 4, 5 }.AsEnumerable();
		var actual = enumerable.IsEmpty();
		Assert.That(actual, Is.False);
	}
	
	[Test]
	public void IsEmpty_EmptyEnumerable_ReturnTrue()
	{
		var enumerable = Array.Empty<int>().AsEnumerable();
		var actual = enumerable.IsEmpty();
		Assert.That(actual, Is.True);
	}
	
	[Test]
	public void Random_NotEmptyEnumerable_ReturnValue()
	{
		var enumerable = new[] { 1, 2, 3, 4, 5 }.AsEnumerable();
		var actual = enumerable.Random(new Random());
		CollectionAssert.Contains(enumerable, actual);
	}
	
	[Test]
	public void Random_EmptyEnumerable_ArgumentOutOfRangeException()
	{
		var enumerable = Array.Empty<int>().AsEnumerable();
		
		Assert.Throws<ArgumentOutOfRangeException>(
			() => enumerable.Random(new Random())
		);
	}
	
	[Test]
	public void GetAllPairs_NotEmptyEnumerable_ReturnPairs()
	{
		var enumerable = new[] { 1, 2, 3 }.AsEnumerable();
		var expected = new[]
		{
			(1, 2),
			(1, 3),
			(2, 3)
		};
		var actual = enumerable.GetAllPairs().ToArray();
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetAllPairs_EmptyEnumerable_ReturnEmpty()
	{
		var enumerable = Array.Empty<int>().AsEnumerable();
		var expected = Array.Empty<int>().AsEnumerable();
		var actual = enumerable.GetAllPairs().ToArray();
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetAllPairs_NotEmptyEnumerables_ReturnPairs()
	{
		var enumerable1 = new[] { 1, 2, 3 }.AsEnumerable();
		var enumerable2 = new[] { 5, 6, 7 }.AsEnumerable();
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
		var actual = enumerable1.GetAllPairs(enumerable2).ToArray();
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetAllPairs_EmptyEnumerable1AndNotEmptyEnumerable2_ReturnEmpty()
	{
		var enumerable1 = Array.Empty<int>().AsEnumerable();
		var enumerable2 = new[] { 3, 4 }.AsEnumerable();
		var expected = Array.Empty<int>().AsEnumerable();
		var actual = enumerable1.GetAllPairs(enumerable2).ToArray();
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetAllPairs_NotEmptyEnumerable1AndEmptyEnumerable2_ReturnEmpty()
	{
		var enumerable1 = new[] { 1, 2 }.AsEnumerable();
		var enumerable2 = Array.Empty<int>().AsEnumerable();
		var expected = Array.Empty<int>().AsEnumerable();
		var actual = enumerable1.GetAllPairs(enumerable2).ToArray();
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetAllPairs_EmptyEnumerables_ReturnEmpty()
	{
		var enumerable1 = Array.Empty<int>().AsEnumerable();
		var enumerable2 = Array.Empty<int>().AsEnumerable();
		var expected = Array.Empty<int>().AsEnumerable();
		var actual = enumerable1.GetAllPairs(enumerable2).ToArray();
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetPairs_NotEmptyEnumerable_ReturnPairs()
	{
		var enumerable = new[] { 1, 2, 3 }.AsEnumerable();
		var expected = new[]
		{
			(1, 2),
			(2, 3)
		};
		var actual = enumerable.GetPairs().ToArray();
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetPairs_2Elements_ReturnPairs()
	{
		var enumerable = new[] { 1, 2 }.AsEnumerable();
		var expected = new[]
		{
			(1, 2)
		};
		var actual = enumerable.GetPairs().ToArray();
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetPairs_1Element_ReturnEmpty()
	{
		var enumerable = new[] { 1 }.AsEnumerable();
		var expected = Array.Empty<int>().AsEnumerable();
		var actual = enumerable.GetPairs().ToArray();
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetPairs_EmptyEnumerable_ReturnEmpty()
	{
		var enumerable = Array.Empty<int>().AsEnumerable();
		var expected = Array.Empty<int>().AsEnumerable();
		var actual = enumerable.GetPairs().ToArray();
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void MinObjectBy_NotEmptyEnumerable_ReturnObject()
	{
		var obj1 = new SimpleObject(3);
		var obj2 = new SimpleObject(1);
		var obj3 = new SimpleObject(2);
		var enumerable = new[] { obj1, obj2, obj3 }.AsEnumerable();
		var actual = enumerable.MinObjectBy(obj => obj.Id);
		Assert.That(actual, Is.EqualTo(obj2));
	}
	
	[Test]
	public void MinObjectBy_EmptyEnumerable_InvalidOperationException()
	{
		var enumerable = Array.Empty<SimpleObject>().AsEnumerable();
		
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
		var enumerable = new[] { obj1, obj2, obj3 }.AsEnumerable();
		var expected = new[] { obj2, obj3 }.AsEnumerable();
		var actual = enumerable.MinObjectsBy(obj => obj.Id);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void MinObjectsBy_EmptyEnumerable_InvalidOperationException()
	{
		var enumerable = Array.Empty<SimpleObject>().AsEnumerable();
		
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
		var enumerable = new[] { obj1, obj2, obj3 }.AsEnumerable();
		var actual = enumerable.MaxObjectBy(obj => obj.Id);
		Assert.That(actual, Is.EqualTo(obj2));
	}
	
	[Test]
	public void MaxObjectBy_EmptyEnumerable_InvalidOperationException()
	{
		var enumerable = Array.Empty<SimpleObject>().AsEnumerable();
		
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
		var enumerable = new[] { obj1, obj2, obj3 }.AsEnumerable();
		var expected = new[] { obj2, obj3 }.AsEnumerable();
		var actual = enumerable.MaxObjectsBy(obj => obj.Id);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void MaxObjectsBy_EmptyEnumerable_InvalidOperationException()
	{
		var enumerable = Array.Empty<SimpleObject>().AsEnumerable();
		
		var exception = Assert.Throws<InvalidOperationException>(
			() => enumerable.MaxObjectsBy(obj => obj.Id)
		);
		Assert.That(exception.Source, Is.EqualTo("Commons"));
	}
	
	[Test]
	public void ClearNull_NotEmptyEnumerable_ReturnWithoutNulls()
	{
		var obj1 = new SimpleObject(1);
		var obj2 = new SimpleObject(2);
		var obj3 = new SimpleObject(3);
		var enumerable = new[] { obj1, null, obj2, null, obj3 }.AsEnumerable();
		var expected = new[] { obj1, obj2, obj3 }.AsEnumerable();
		var actual = enumerable.ClearNull();
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void ClearNull_EmptyEnumerable_ReturnEmpty()
	{
		var enumerable = Array.Empty<SimpleObject>().AsEnumerable();
		var expected = Array.Empty<SimpleObject>().AsEnumerable();
		var actual = enumerable.ClearNull();
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void OfTypeName_NotEmptyEnumerable_ReturnObjects()
	{
		var obj1 = new SimpleObject(1);
		var obj2 = new NestedSimpleObject(2);
		var obj3 = new SimpleObject(3);
		var enumerable = new[] { obj1, obj2, obj3 }.AsEnumerable();
		var expected = new[] { obj1, obj3 }.AsEnumerable();
		var actual = enumerable.OfTypeName("SimpleObject");
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void OfTypeName_AbsentTypeName_ReturnObjects()
	{
		var obj1 = new SimpleObject(1);
		var obj2 = new NestedSimpleObject(2);
		var obj3 = new SimpleObject(3);
		var enumerable = new[] { obj1, obj2, obj3 }.AsEnumerable();
		var expected = Array.Empty<SimpleObject>().AsEnumerable();
		var actual = enumerable.OfTypeName("ParentSimpleObject");
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void OfTypeName_EmptyEnumerable_ReturnObjects()
	{
		var enumerable = Array.Empty<SimpleObject>().AsEnumerable();
		var expected = Array.Empty<SimpleObject>().AsEnumerable();
		var actual = enumerable.OfTypeName("SimpleObject");
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void ForEach_NotEmptyEnumerable_WorksCorrectly()
	{
		var obj1 = new SimpleObject(1);
		var obj2 = new SimpleObject(2);
		var obj3 = new SimpleObject(3);
		var enumerable = new[] { obj1, obj2, obj3 }.AsEnumerable();
		var expected = new[] { 2, 3, 4 }.AsEnumerable();
		enumerable.ForEach(obj => obj.Id += 1);
		var actual = enumerable.Select(obj => obj.Id);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void ForEach_EmptyEnumerable_WorksCorrectly()
	{
		var enumerable = Array.Empty<SimpleObject>().AsEnumerable();
		var expected = Array.Empty<SimpleObject>().AsEnumerable();
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
		var enumerable = new[] { obj1, obj2, obj3 }.AsEnumerable();
		var expected = new[] { 2, 4, 6 }.AsEnumerable();
		enumerable.ForEachIndex((obj, index) => obj.Id += 1 + index);
		var actual = enumerable.Select(obj => obj.Id);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void ForEachIndex_EmptyEnumerable_WorksCorrectly()
	{
		var enumerable = Array.Empty<SimpleObject>().AsEnumerable();
		var expected = Array.Empty<SimpleObject>().AsEnumerable();
		enumerable.ForEachIndex((obj, index) => obj.Id += 1 + index);
		var actual = enumerable.Select(obj => obj.Id);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void IndexOf_NotEmptyEnumerable_ReturnIndex()
	{
		var obj1 = new SimpleObject(1);
		var obj2 = new SimpleObject(2);
		var obj3 = new SimpleObject(3);
		var enumerable = new[] { obj1, obj2, obj3 }.AsEnumerable();
		var actual = enumerable.IndexOf(obj => obj.Id == 2);
		Assert.That(actual, Is.EqualTo(1));
	}
	
	[Test]
	public void IndexOf_EmptyEnumerable_InvalidOperationException()
	{
		var enumerable = Array.Empty<SimpleObject>().AsEnumerable();
		Assert.Throws<InvalidOperationException>(
			() => enumerable.IndexOf(obj => obj.Id == 2)
		);
	}
	
	[Test]
	public void IndicesOf_NotEmptyEnumerable_ReturnIndices()
	{
		var obj1 = new SimpleObject(1);
		var obj2 = new SimpleObject(2);
		var obj3 = new SimpleObject(1);
		var enumerable = new[] { obj1, obj2, obj3 }.AsEnumerable();
		var expected = new[] { 0, 2 }.AsEnumerable();
		var actual = enumerable.IndicesOf(obj => obj.Id == 1);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void IndicesOf_EmptyEnumerable_ReturnIndices()
	{
		var enumerable = Array.Empty<SimpleObject>().AsEnumerable();
		var expected = Array.Empty<SimpleObject>().AsEnumerable();
		var actual = enumerable.IndicesOf(obj => obj.Id == 1);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void IndicesOf_ValueAndNotEmptyEnumerable_ReturnIndices()
	{
		var obj1 = new SimpleObject(1);
		var obj2 = new SimpleObject(2);
		var obj3 = new SimpleObject(1);
		var enumerable = new[] { obj1, obj2, obj3, obj1 }.AsEnumerable();
		var expected = new[] { 0, 3 }.AsEnumerable();
		var actual = enumerable.IndicesOf(obj1);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void IndicesOf_ValueAndEmptyEnumerable_ReturnEmpty()
	{
		var enumerable = Array.Empty<SimpleObject>().AsEnumerable();
		var expected = Array.Empty<SimpleObject>().AsEnumerable();
		var actual = enumerable.IndicesOf(new SimpleObject(1));
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void IndicesOf_ValueAndNotEmptyEnumerableEquatable_ReturnIndices()
	{
		var obj1 = new EquatableSimpleObject(1);
		var obj2 = new EquatableSimpleObject(2);
		var obj3 = new EquatableSimpleObject(1);
		var enumerable = new[] { obj1, obj2, obj3 }.AsEnumerable();
		var expected = new[] { 0, 2 }.AsEnumerable();
		var actual = enumerable.IndicesOf(obj1);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void IndicesOf_NullAndNotEmptyEnumerableEquatable_ReturnIndices()
	{
		var obj1 = new EquatableSimpleObject(1);
		var obj2 = new EquatableSimpleObject(2);
		var obj3 = new EquatableSimpleObject(1);
		var enumerable = new[] { obj1, null, obj2, null, obj3 }.AsEnumerable();
		var expected = new[] { 1, 3 }.AsEnumerable();
		var actual = enumerable.IndicesOf(null as EquatableSimpleObject);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void IndicesOf_ValuesAndNotEmptyEnumerable_ReturnIndices()
	{
		var obj1 = new SimpleObject(1);
		var obj2 = new SimpleObject(2);
		var obj3 = new SimpleObject(3);
		var enumerable = new[] { obj1, obj2, obj3 }.AsEnumerable();
		var expected = new[] { 0, 2 }.AsEnumerable();
		var actual = enumerable.IndicesOf([obj1, obj3]);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void IndicesOf_ValuesAndEmptyEnumerable_ReturnEmpty()
	{
		var enumerable = Array.Empty<SimpleObject>().AsEnumerable();
		var expected = Array.Empty<SimpleObject>().AsEnumerable();
		var actual = enumerable.IndicesOf([new SimpleObject(1)]);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void IndicesOf_ValuesAndNotEmptyEnumerableEquatable_ReturnIndices()
	{
		var obj1 = new EquatableSimpleObject(1);
		var obj2 = new EquatableSimpleObject(2);
		var obj3 = new EquatableSimpleObject(3);
		var enumerable = new[] { obj1, obj2, obj3 }.AsEnumerable();
		var expected = new[] { 0, 2 }.AsEnumerable();
		var actual = enumerable.IndicesOf([obj1, obj3]);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void EqualsTo_Enumerable1EqualEnumerable2Ordered_ReturnTrue()
	{
		var enumerable1 = new[] { 1, 2, 3, 4 }.AsEnumerable();
		var enumerable2 = new[] { 1, 2, 3, 4 }.AsEnumerable();
		var actual = enumerable1.SequenceEqualDisorder(enumerable2);
		Assert.That(actual, Is.True);
	}
	
	[Test]
	public void EqualsTo_Enumerable1EqualEnumerable2Disordered_ReturnTrue()
	{
		var enumerable1 = new[] { 1, 2, 3, 4 }.AsEnumerable();
		var enumerable2 = new[] { 4, 3, 2, 1 }.AsEnumerable();
		var actual = enumerable1.SequenceEqualDisorder(enumerable2);
		Assert.That(actual, Is.True);
	}
	
	[Test]
	public void EqualsTo_Enumerable1NotEqualEnumerable2_ReturnFalse()
	{
		var enumerable1 = new[] { 1, 2, 3, 4 }.AsEnumerable();
		var enumerable2 = new[] { 1, 2, 3 }.AsEnumerable();
		var actual = enumerable1.SequenceEqualDisorder(enumerable2);
		Assert.That(actual, Is.False);
	}
	
	[Test]
	public void EqualsTo_EmptyEnumerables_ReturnTrue()
	{
		var enumerable1 = Array.Empty<int>().AsEnumerable();
		var enumerable2 = Array.Empty<int>().AsEnumerable();
		var actual = enumerable1.SequenceEqualDisorder(enumerable2);
		Assert.That(actual, Is.True);
	}
	
	[Test]
	public void EqualsToOrdered_Enumerable1EqualEnumerable2Ordered_ReturnTrue()
	{
		var enumerable1 = new[] { 1, 2, 3, 4 }.AsEnumerable();
		var enumerable2 = new[] { 1, 2, 3, 4 }.AsEnumerable();
		var actual = enumerable1.SequenceEqual(enumerable2);
		Assert.That(actual, Is.True);
	}
	
	[Test]
	public void EqualsToOrdered_Enumerable1EqualEnumerable2Disordered_ReturnFalse()
	{
		var enumerable1 = new[] { 1, 2, 3, 4 }.AsEnumerable();
		var enumerable2 = new[] { 4, 3, 2, 1 }.AsEnumerable();
		var actual = enumerable1.SequenceEqual(enumerable2);
		Assert.That(actual, Is.False);
	}
	
	[Test]
	public void EqualsToOrdered_Enumerable1NotEqualEnumerable2_ReturnFalse()
	{
		var enumerable1 = new[] { 1, 2, 3, 4 }.AsEnumerable();
		var enumerable2 = new[] { 1, 2, 3 }.AsEnumerable();
		var actual = enumerable1.SequenceEqual(enumerable2);
		Assert.That(actual, Is.False);
	}
	
	[Test]
	public void EqualsToOrdered_EmptyEnumerables_ReturnTrue()
	{
		var enumerable1 = Array.Empty<int>().AsEnumerable();
		var enumerable2 = Array.Empty<int>().AsEnumerable();
		var actual = enumerable1.SequenceEqual(enumerable2);
		Assert.That(actual, Is.True);
	}
	
	[Test]
	public void GetRange_NotEmptyEnumerable_ReturnValues()
	{
		var enumerable = new[] { 1, 2, 3, 4 }.AsEnumerable();
		var expected = new[] { 2, 3 };
		var actual = enumerable.GetRange(1, 2);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetRange_EmptyEnumerable_ReturnEmpty()
	{
		var enumerable = Array.Empty<int>().AsEnumerable();
		var expected = Array.Empty<int>().AsEnumerable();
		var actual = enumerable.GetRange(1, 2);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetRange_NegativeIndex_ReturnValues()
	{
		var enumerable = new[] { 1, 2, 3, 4 }.AsEnumerable();
		var expected = new[] { 1, 2 };
		var actual = enumerable.GetRange(-10, 2);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetRange_NegativeCount_ReturnEmpty()
	{
		var enumerable = new[] { 1, 2, 3, 4 }.AsEnumerable();
		var expected = Array.Empty<int>().AsEnumerable();
		var actual = enumerable.GetRange(1, -2);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	private class SimpleObject(int id)
	{
		public int Id { get; set; } = id;
	}

	private sealed class NestedSimpleObject(int id) : SimpleObject(id);
	
	private sealed class EquatableSimpleObject(int id) : IEquatable<EquatableSimpleObject>
	{
		private int Id { get; } = id;
		
		public bool Equals(EquatableSimpleObject? other)
		{
			if (other is null) return false;
			if (ReferenceEquals(this, other)) return true;
			return Id == other.Id;
		}

		public override bool Equals(object? obj)
		{
			if (obj is null) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((EquatableSimpleObject)obj);
		}

		public override int GetHashCode()
		{
			return Id;
		}
	}
}
#pragma warning restore CA1861