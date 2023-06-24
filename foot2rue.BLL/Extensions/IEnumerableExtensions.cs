namespace foot2rue.BLL.Extensions
{
	internal static class IEnumerableExtensions
	{
		public static IEnumerable<T> IfNotNull<T>(this IEnumerable<T>? enumerable)
		{
			if (enumerable == null)
				return Enumerable.Empty<T>();
			return enumerable;
		}
	}
}
