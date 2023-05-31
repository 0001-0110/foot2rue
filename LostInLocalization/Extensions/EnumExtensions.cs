namespace LostInLocalization.Extensions
{
    public static class EnumExtensions
    {
        public static string GetLocalizedString<T>(this T self) where T : Enum
        {
            return LocalizationService.Instance.GetLocalizedString($"{{Enum_{self}}}");
        }
    }
}
