using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace foot2rue.WPF.Extensions
{
	internal static class PanelExtensions
    {
        public static void SetChildren<T>(this Panel panel, IEnumerable<T> children) where T : UIElement
        {
            panel.Children.Clear();
            panel.Children.AddRange(children);
        }
    }
}
