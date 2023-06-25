using System.Collections.Generic;
using System.Windows.Controls;

namespace foot2rue.WPF.Extensions
{
    internal static class ItemCollectionExtensions
    {
        public static void AddRange<T>(this ItemCollection collection, IEnumerable<T> items)
        {
            foreach (T item in items)
                collection.Add(item);
        }
    }
}
