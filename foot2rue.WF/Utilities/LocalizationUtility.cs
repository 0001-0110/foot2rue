﻿using foot2rue.WF.Localization;
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

        public static CultureInfo GetCulture()
        {
            return CultureInfo.CurrentCulture;
        }

        public static bool IsCurrentCulture(CultureInfo culture)
        {
            return GetCulture().Equals(culture);
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
