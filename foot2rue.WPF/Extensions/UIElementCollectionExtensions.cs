using foot2rue.BLL.Extensions;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace foot2rue.WPF.Extensions
{
    internal static class UIElementCollectionExtensions
    {
        public static void AddRange(this UIElementCollection collection, IEnumerable<UIElement>? elements)
        {
            foreach (UIElement element in elements.EmptyIfNull())
                collection.Add(element);
        }
    }
}
