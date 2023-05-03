using foot2rue.WF.Localization;
using System.Globalization;

namespace foot2rue.WF.Utilities
{
    internal static class LocalizationUtility
    {
        public static IEnumerable<CultureInfo> GetAllSupportedLanguages()
        {
            foreach (SupportedLanguage language in EnumUtility.GetEnumValues<SupportedLanguage>())
                yield return new CultureInfo((int)language);
        }

        public static void SetCulture(CultureInfo culture)
        {
            // Localization
            Thread.CurrentThread.CurrentUICulture = culture;
            // Globalization
            Thread.CurrentThread.CurrentCulture = culture;
        }
    }
}
