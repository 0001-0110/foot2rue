namespace LostInLocalization.Extensions
{
	public static class EnumExtensions
	{
		public static string GetLocalizedString<T>(this T self) where T : Enum
		{
			return LocalizationService.Instance.GetLocalizedString($"{{Enum_{self}}}");

			#region On a tree

			// Yahaha, you found me!

			#endregion
		}
	}
}
