using System;

namespace foot2rue.WPF.Extensions
{
    internal static class TupleExtensions
    {
        public static T GetIndex<T>(this (T, T) tuple, int index)
        {
            return index switch
            {
                0 => tuple.Item1,
                1 => tuple.Item2,
                _ => throw new ArgumentException()
            };
        }
    }
}
