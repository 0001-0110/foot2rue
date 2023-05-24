using foot2rue.WF.Services;

namespace foot2rue.WF.Extensions
{
    internal static class EnumExtensions
    {
        public static string GetLocalizedString<T>(this T self) where T : Enum
        {
            return LocalizationService.Instance.GetLocalizedString($"{{Enum_{self}}}");
        }
    }
}
