using foot2rue.BLL.Models;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Automation;
using System.Windows.Media.Imaging;

namespace foot2rue.WPF.Utilities
{
    internal static class ResourcesUtility
    {
        /// <summary>
        /// Takes a bitmap and converts it to an image that can be handled by WPF ImageBrush
        /// </summary>
        /// <param name="source">A bitmap image</param>
        /// <returns>The image as a BitmapImage for WPF</returns>
        /// <remarks>https://stackoverflow.com/questions/26260654/wpf-converting-bitmap-to-imagesource</remarks>
        public static BitmapImage ConvertToWpfImage(Bitmap? source)
        {
            if (source == null)
                return null!;

            MemoryStream memoryStream = new();
            source.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new();
            image.BeginInit();
            memoryStream.Seek(0, SeekOrigin.Begin);
            image.StreamSource = memoryStream;
            image.EndInit();
            return image;
        }

        private static object? GetResource(string resourceName, bool ignoreCase = false)
        {
            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Static | (ignoreCase ? BindingFlags.IgnoreCase : BindingFlags.Default);
            // Null because these properties are static, hence no instance to pass
            return typeof(Properties.Resources).GetProperty(resourceName, bindingFlags)?.GetValue(null);
        }

        private static T? GetResource<T>(string resourceName, bool ignoreCase = false)
        {
            return (T?)GetResource(resourceName, ignoreCase);
        }

        public static Bitmap? GetPlayerImage(Player player)
        {
            return GetResource<Bitmap>(player.Name);
        }

        public static Bitmap? GetCountryImage(string fifaCode)
        {
            return GetResource<Bitmap>(fifaCode, true);
        }

        public static Bitmap? GetEventIcon(string eventType)
        {
            throw new NotImplementedException();
            //return GetResource<Bitmap>();
        }
    }
}
