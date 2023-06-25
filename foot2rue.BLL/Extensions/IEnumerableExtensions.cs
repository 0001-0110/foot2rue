namespace foot2rue.BLL.Extensions
{
	public static class IEnumerableExtensions
	{
		public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T>? enumerable)
		{
			if (enumerable == null)
				return Enumerable.Empty<T>();
			return enumerable;
		}
	}
}
