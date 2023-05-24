namespace foot2rue.WF.Extensions
{
    internal static class DictionnaryExtensions
    {
        public static void SetOrAddKey<TKey, TValue>(this Dictionary<TKey, TValue> dictionnary, TKey key, TValue value) where TKey : notnull
        {
            if (dictionnary.ContainsKey(key))
                dictionnary[key] = value;
            else 
                dictionnary.Add(key, value);
        }
    }
}
