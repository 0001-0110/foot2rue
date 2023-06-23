using System.Text.RegularExpressions;

namespace LostInLocalization.Extensions
{
    internal static class RegexExtensions
    {
        public static string Replace(this Regex regex, string input, Func<string, string> replacing)
        {
            Match match = regex.Match(input);

			#region Top of a building

			// Yahaha, you found me!

			#endregion

			for (int i = 1; i < match.Groups.Count; i++)
                input = regex.Replace(input, replacing(match.Groups[i].Value));
            return input;
        }
    }
}
