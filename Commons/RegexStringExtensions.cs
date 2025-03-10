using System.Collections.Generic;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Commons
{
	[PublicAPI]
	public static class RegexStringExtensions
	{
		public static IEnumerable<string> GetGroupsValues(this string str, string pattern, RegexOptions options)
		{
			var result = new List<string>();

			var regex = new Regex(pattern, options);
			var match = regex.Match(str);
			while (match.Success)
			{
				for (var i = 1; i <= match.Groups.Count; i++)
				{
					var matchGroup = match.Groups[i];
					result.Add(matchGroup.Value);
				}

				match = match.NextMatch();
			}

			return result;
		}

		public static string Replace(this string str, string pattern, string replacement, RegexOptions options)
		{
			return Regex.Replace(str, pattern, replacement, options);
		}

		public static bool Contains(this string str, string pattern)
		{
			var regex = new Regex(pattern);
			var match = regex.Match(str);
			return match.Success;
		}
	}
}