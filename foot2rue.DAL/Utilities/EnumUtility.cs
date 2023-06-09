namespace foot2rue.DAL.Utilities
{
    public static class EnumUtility
    {
        public static IEnumerable<T> GetEnumValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
