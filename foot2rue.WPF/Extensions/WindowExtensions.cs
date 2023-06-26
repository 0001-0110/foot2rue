using foot2rue.BLL.Models;
using System.Windows;

namespace foot2rue.WPF.Extensions
{
    internal static class WindowExtensions
    {
        public static Resolution GetResolution(this Window window)
        {
            return new Resolution(window.Width, window.Height);
        }

        public static void Resize(this Window window, Resolution resolution)
        {
            window.Width = resolution.Width;
            window.Height = resolution.Height;
        }
    }
}
