namespace foot2rue.WF.Utilities
{
	internal static class ColorUtility
	{
		public static Color FromHex(string hexCode)
		{
			return ColorTranslator.FromHtml(hexCode);
		}

		public static Color GetAverageColor(Bitmap bitmap)
		{
			int totalPixels = bitmap.Width * bitmap.Height;
			int redSum = 0;
			int greenSum = 0;
			int blueSum = 0;

			for (int y = 0; y < bitmap.Height; y++)
			{
				for (int x = 0; x < bitmap.Width; x++)
				{
					Color pixelColor = bitmap.GetPixel(x, y);
					redSum += pixelColor.R;
					greenSum += pixelColor.G;
					blueSum += pixelColor.B;
				}
			}

			int averageRed = redSum / totalPixels;
			int averageGreen = greenSum / totalPixels;
			int averageBlue = blueSum / totalPixels;

			return Color.FromArgb(averageRed, averageGreen, averageBlue);
		}
	}
}
