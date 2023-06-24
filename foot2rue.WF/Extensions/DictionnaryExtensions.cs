namespace foot2rue.WF.Extensions
{
	internal static class DictionnaryExtensions
	{
		public static void SetOrAddKey<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value) where TKey : notnull
		{
			if (dictionary.ContainsKey(key))
				dictionary[key] = value;
			else
				dictionary.Add(key, value);
		}
	}
}
