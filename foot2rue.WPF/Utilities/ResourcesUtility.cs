using foot2rue.BLL.Models;
using System.Drawing;
using System.Reflection;

namespace foot2rue.WF.Utilities
{
	internal static class ResourcesUtility
	{
		private static object? GetResource(string resourceName, bool ignoreCase = false)
		{
			BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Static | (ignoreCase ? BindingFlags.IgnoreCase : BindingFlags.Default);
			// Null because these properties are static, hence no instance to pass
			return typeof(WPF.Properties.Resources).GetProperty(resourceName, bindingFlags)?.GetValue(null);
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
	}
}
