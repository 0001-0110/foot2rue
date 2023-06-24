using System.Reflection;

namespace foot2rue.Settings.Extensions
{
	public static class ObjectExtensions
	{
		/// <summary>
		/// This is SOOOOOOOOOOOOOOO overengineered for what I need
		/// </summary>
		/// <typeparam name="TParent"></typeparam>
		/// <typeparam name="TChild"></typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		/// <remarks>This is funny though</remarks>
		public static void GetDataFrom<TSource, TDestination>(this TDestination destination, TSource source, bool overrideValues = false) where TSource : notnull where TDestination : notnull, TSource
		{
			BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
			PropertyInfo[] sourceProperties = source.GetType().GetProperties(bindingFlags);
			PropertyInfo[] destinationProperties = destination.GetType().GetProperties(bindingFlags);
			foreach (PropertyInfo sourceProperty in sourceProperties)
			{
				PropertyInfo? destinationProperty = Array.Find(destinationProperties, property => property.Name == sourceProperty.Name);
				if (destinationProperty != null && destinationProperty.PropertyType == sourceProperty.PropertyType && destinationProperty.CanWrite)
				{
					if ((!overrideValues && destinationProperty.GetValue(destination) != default) || sourceProperty.GetValue(source) == default)
						continue;
					destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
				}
			}
		}

		public static TChild ExtendParentClass<TParent, TChild>(this TParent source) where TParent : notnull where TChild : notnull, TParent, new()
		{
			TChild destination = new TChild();
			destination.GetDataFrom(source, true);
			return destination;
		}
	}
}
