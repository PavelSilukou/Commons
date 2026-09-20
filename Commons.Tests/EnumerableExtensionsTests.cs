namespace Commons.Tests;

#pragma warning disable CA1861 // Avoid constant arrays as arguments
#pragma warning disable CA1707 // Identifiers should not contain underscores
public class EnumerableExtensionsTests
{
	[Test]
	public void ClearNull_NotEmptyEnumerable_ReturnWithoutNulls()
	{
		var obj1 = new SimpleObject(1);
		var obj2 = new SimpleObject(2);
		var obj3 = new SimpleObject(3);
		var enumerable = new[] { obj1, null, obj2, null, obj3 };
		var expected = new[] { obj1, obj2, obj3 };
		var actual = enumerable.ClearNull();
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void ClearNull_EmptyEnumerable_ReturnEmpty()
	{
		var enumerable = Array.Empty<SimpleObject>();
		var expected = Array.Empty<SimpleObject>();
		var actual = enumerable.ClearNull();
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void OfTypeName_NotEmptyEnumerable_ReturnObjects()
	{
		var obj1 = new SimpleObject(1);
		var obj2 = new NestedSimpleObject(2);
		var obj3 = new SimpleObject(3);
		var enumerable = new[] { obj1, obj2, obj3 };
		var expected = new[] { obj1, obj3 };
		var actual = enumerable.OfTypeName(nameof(SimpleObject));
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void OfTypeName_AbsentTypeName_ReturnObjects()
	{
		var obj1 = new SimpleObject(1);
		var obj2 = new NestedSimpleObject(2);
		var obj3 = new SimpleObject(3);
		var enumerable = new[] { obj1, obj2, obj3 };
		var expected = Array.Empty<SimpleObject>();
		var actual = enumerable.OfTypeName("ParentSimpleObject");
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void OfTypeName_EmptyEnumerable_ReturnObjects()
	{
		var enumerable = Array.Empty<SimpleObject>();
		var expected = Array.Empty<SimpleObject>();
		var actual = enumerable.OfTypeName(nameof(SimpleObject));
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void Index_NotEmptyEnumerable_ReturnIndices()
	{
		var obj1 = new SimpleObject(1);
		var obj2 = new SimpleObject(2);
		var obj3 = new SimpleObject(1);
		var enumerable = new[] { obj1, obj2, obj3 };
		var expected = new[] { (obj1, 0), (obj3, 2) };
		var actual = enumerable.Index(obj => obj.Id == 1);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void Index_EmptyEnumerable_ReturnIndices()
	{
		var enumerable = Array.Empty<SimpleObject>();
		var expected = Array.Empty<SimpleObject>();
		var actual = enumerable.Index(obj => obj.Id == 1);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void Index_ValueAndNotEmptyEnumerable_ReturnIndices()
	{
		var obj1 = new SimpleObject(1);
		var obj2 = new SimpleObject(2);
		var obj3 = new SimpleObject(1);
		var enumerable = new[] { obj1, obj2, obj3, obj1 };
		var expected = new[] { (obj1, 0), (obj1, 3) };
		var actual = enumerable.Index(obj1);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void Index_ValueAndEmptyEnumerable_ReturnEmpty()
	{
		var enumerable = Array.Empty<SimpleObject>();
		var expected = Array.Empty<SimpleObject>();
		var actual = enumerable.Index(new SimpleObject(1));
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void Index_ValueAndNotEmptyEnumerableEquatable_ReturnIndices()
	{
		var obj1 = new EquatableSimpleObject(1);
		var obj2 = new EquatableSimpleObject(2);
		var obj3 = new EquatableSimpleObject(1);
		var enumerable = new[] { obj1, obj2, obj3 };
		var expected = new[] { (obj1, 0), (obj3, 2) };
		var actual = enumerable.Index(obj1);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void Index_NullAndNotEmptyEnumerableEquatable_ReturnIndices()
	{
		var obj1 = new EquatableSimpleObject(1);
		var obj2 = new EquatableSimpleObject(2);
		var obj3 = new EquatableSimpleObject(1);
		var enumerable = new[] { obj1, null, obj2, null, obj3 };
		var expected = new (EquatableSimpleObject, int)[] { (null, 1)!, (null, 3)! };
		var actual = enumerable.Index(null as EquatableSimpleObject);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void Index_ValuesAndNotEmptyEnumerable_ReturnIndices()
	{
		var obj1 = new SimpleObject(1);
		var obj2 = new SimpleObject(2);
		var obj3 = new SimpleObject(3);
		var enumerable = new[] { obj1, obj2, obj3 };
		var expected = new[] { (obj1, 0), (obj3, 2) };
		var actual = enumerable.Index([obj1, obj3]);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void Index_ValuesAndEmptyEnumerable_ReturnEmpty()
	{
		var enumerable = Array.Empty<SimpleObject>();
		var expected = Array.Empty<SimpleObject>();
		var actual = enumerable.Index([new SimpleObject(1)]);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void Index_ValuesAndNotEmptyEnumerableEquatable_ReturnIndices()
	{
		var obj1 = new EquatableSimpleObject(1);
		var obj2 = new EquatableSimpleObject(2);
		var obj3 = new EquatableSimpleObject(3);
		var enumerable = new[] { obj1, obj2, obj3 };
		var expected = new[] { (obj1, 0), (obj3, 2) };
		var actual = enumerable.Index([obj1, obj3]);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetRange_NotEmptyEnumerable_ReturnValues()
	{
		var enumerable = new[] { 1, 2, 3, 4 };
		var expected = new[] { 2, 3 };
		var actual = enumerable.GetRange(1, 2);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetRange_EmptyEnumerable_ReturnEmpty()
	{
		var enumerable = Array.Empty<int>();
		var expected = Array.Empty<int>();
		var actual = enumerable.GetRange(1, 2);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetRange_NegativeIndex_ReturnValues()
	{
		var enumerable = new[] { 1, 2, 3, 4 };
		var expected = new[] { 1, 2 };
		var actual = enumerable.GetRange(-10, 2);
		CollectionAssert.AreEqual(expected, actual);
	}
	
	[Test]
	public void GetRange_NegativeCount_ReturnEmpty()
	{
		var enumerable = new[] { 1, 2, 3, 4 };
		var expected = Array.Empty<int>();
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