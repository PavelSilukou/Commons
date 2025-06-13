namespace Commons.Tests;

public class ConvertExtensionsTests
{
	[Test]
	public void GetValue_StringObjectToStringCast_ReturnStringType()
	{
		object strObject = "Hello World";
		var str = strObject.GetValue<string>();
		var actualType = str.GetType();
		Assert.That(actualType, Is.EqualTo(typeof(string)));
	}
	
	[Test]
	public void GetValue_StringObjectToInt32Cast_FormatException()
	{
		object strObject = "Hello World";
		
		Assert.Throws<FormatException>(
			() => strObject.GetValue<int>()
		);
	}
	
	[Test]
	public void GetValue_ByteObjectToInt32Cast_ReturnInt32Type()
	{
		object byteObject = 15;
		var int32 = byteObject.GetValue<int>();
		var actualType = int32.GetType();
		Assert.That(actualType, Is.EqualTo(typeof(int)));
	}
}