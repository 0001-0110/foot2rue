namespace foot2rue.Settings.Extensions
{
	internal static class StringExtensions
	{
		public static string Troncate(this string str, string separator, int troncate)
		{
			string[] split = str.Split(separator);
			if (troncate >= 0)
				return string.Join(separator, split.Take(troncate));
			else
				return string.Join(separator, split.Take(split.Length - (-troncate)));
		}
	}
}
