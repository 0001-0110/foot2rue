using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace foot2rue.WPF.Settings
{
    internal class Resolution
    {
        public static readonly Resolution[] AllResolutions = new Resolution[] { new(800, 450) };

        public readonly int Width;
        public readonly int Height;

        public static IEnumerable<Resolution> AvailableResolutions()
        {
            return AllResolutions.Where(resolution => resolution.IsAvailable());
        }

        public Resolution(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Check if this resolution is smaller or equal than the current screen resolution
        /// </summary>
        /// <param name="screenResolution"></param>
        /// <returns></returns>
        public bool IsAvailable()
        {
            return Width <= Screen.PrimaryScreen.Bounds.Width && Height <= Screen.PrimaryScreen.Bounds.Height;
        }
    }
}
