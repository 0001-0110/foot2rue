namespace foot2rue.WF.Extensions
{
    internal static class DictionnaryExtensions
    {
        public static void SetOrAddKey<TKey, TValue>(this Dictionary<TKey, TValue> dictionnary, TKey key, TValue value)
        {
            if (dictionnary.ContainsKey(key))
                dictionnary[key] = value;
            else 
                dictionnary.Add(key, value);
        }
    }
}
