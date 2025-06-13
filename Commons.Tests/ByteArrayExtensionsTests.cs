using System.Text;
using Commons.Collections;

namespace Commons.Tests;

public class ByteArrayExtensionsTests
{
	[Test]
	public void GetString_NoEncoding_ReturnString()
	{
		// ReSharper disable once UseUtf8StringLiteral
		var byteArrayStr = new byte[] { 72, 101, 108, 108, 111, 32, 87, 111, 114, 108, 100 };
		var actual = byteArrayStr.GetString();
		Assert.That(actual, Is.EqualTo("Hello World"));
	}
	
	[Test]
	public void GetString_UTF8Encoding_ReturnString()
	{
		// ReSharper disable once UseUtf8StringLiteral
		var byteArrayStr = new byte[] { 72, 101, 108, 108, 111, 32, 87, 111, 114, 108, 100 };
		var actual = byteArrayStr.GetString(Encoding.UTF8);
		Assert.That(actual, Is.EqualTo("Hello World"));
	}
}