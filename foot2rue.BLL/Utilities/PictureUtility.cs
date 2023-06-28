using foot2rue.DAL.Models;
using System.IO;

namespace foot2rue.BLL.Utilities
{
	[Obsolete]
	internal static class PictureUtility
	{
		private const string RESOURCESFOLDER = "Resources";
		private static readonly string RESOURCESPATH = Path.Combine(Application.StartupPath, RESOURCESFOLDER);

		public static Image? LoadPlayerPicture(Player player)
		{
			// TODO Is this the correct file type ?
			return LoadFromResources($"{player.Name}.jpg");
		}

		public static void SaveToResources(Image image, string filename, string extension = "jpg")
		{
			image.Save(Path.Combine(RESOURCESPATH, $"{filename}.{extension}"));
		}

		public static Image? LoadFromResources(string filename)
		{
			string filePath = Path.Combine(RESOURCESPATH, filename);
			if (!File.Exists(filePath))
				return null;
			return Image.FromFile(filePath);
		}
	}
}
