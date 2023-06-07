﻿using LostInLocalization.Extensions;
using LostInLocalization.Utilities;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;

namespace LostInLocalization
{
    public class LocalizationService
    {
        private readonly string LOCALIZATIONFOLDER = "LocalizationFiles";
        // Matches and capture evertythin inside curly braces
        private static readonly Regex localizationRegex = new Regex("{([^}]*)}");
        public static readonly CultureInfo DefaultCulture = new CultureInfo((int)SupportedLanguage.English_US);

        public static LocalizationService Instance = new LocalizationService();

        private Dictionary<string, string> localizationStrings;

        private CultureInfo culture;
        public CultureInfo Culture
        {
            get
            {
                return culture;
            }
            set
            {
                if (!IsSupportedLanguage(value))
                {
                    culture = DefaultCulture;
                    return;
                }

                culture = value;
                // Localization
                Thread.CurrentThread.CurrentUICulture = value;
                // Globalization
                Thread.CurrentThread.CurrentCulture = value;

                LoadLocalizationFile();
            }
        }

        private LocalizationService()
        {
            Culture = DefaultCulture;
            // Not awaited on purpose
            LoadLocalizationFile();
        }

        public static IEnumerable<CultureInfo> GetAllSupportedLanguages()
        {
            foreach (SupportedLanguage language in EnumUtility.GetEnumValues<SupportedLanguage>())
                yield return new CultureInfo((int)language);
        }

        public static bool IsSupportedLanguage(CultureInfo culture)
        {
            return Enum.IsDefined((SupportedLanguage)culture.LCID);
        }

        public bool IsCurrentCulture(CultureInfo culture)
        {
            return Culture.Equals(culture);
        }

        private void LoadLocalizationFile()
        {
            localizationStrings = new Dictionary<string, string>();

            string path = Path.Combine(Directory.GetCurrentDirectory(), LOCALIZATIONFOLDER, $"{Culture.Name}.xml");
            XmlDocument? localizationFile = XmlUtility.LoadXml(path);
            if (localizationFile == null)
                // File does not exist
                return;
            XmlNodeList? xmlNodeList = localizationFile.SelectNodes($"localization/string");
            if (xmlNodeList == null)
                // File does not respect the expected format
                return;

            foreach (XmlNode node in xmlNodeList)
            {
                if (node.InnerText == string.Empty)
                {
                    Debug.WriteLine("Missing localization string");
                    continue;
                }

                localizationStrings.Add(node.Attributes!["name"]!.Value, node.InnerText);
            }
        }

        public string GetLocalizedString(string localizationString)
        {
            return localizationRegex.Replace(localizationString, str => localizationStrings.GetValueOrDefault(str, $"{{{str}}}"));
        }

        public string Globalize(int value)
        {
            return value.ToString(Culture);
        }

        public string Globalize(float value)
        {
            return value.ToString(Culture);
        }

        public string Globalize(double value)
        {
            return value.ToString(Culture);
        }

        public string Globalize(string value) 
        {
            return value.ToString(Culture);
        }
    }
}
