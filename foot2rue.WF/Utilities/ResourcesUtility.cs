using foot2rue.BLL.Models;
using System.Reflection;

namespace foot2rue.WF.Utilities
{
	internal static class ResourcesUtility
	{
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

		public static Image? GetPlayerImage(PlayerCupResult player)
		{
			return GetResource<Bitmap>(player.Name.Replace(' ', '_'), true);
		}

		public static Image? GetCountryImage(string fifaCode)
		{
			return GetResource<Image>(fifaCode, true);
		}
	}
}
