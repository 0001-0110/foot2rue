namespace foot2rue.WF.Utilities
{
    internal static class EnumUtility
    {
        public static IEnumerable<T> GetEnumValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
