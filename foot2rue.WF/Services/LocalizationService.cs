using foot2rue.WF.Extensions;
using foot2rue.WF.Localization;
using foot2rue.WF.Utilities;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;

namespace foot2rue.WF.Services
{
    internal class LocalizationService
    {
        private readonly string LOCALIZATIONFOLDER = Path.Combine("Localization", "LocalizationFiles");
        // Matches and capture evertythin inside curly braces
        private static readonly Regex localizationRegex = new Regex("{([^}]*)}");
        private static readonly CultureInfo DefaultCulture = new CultureInfo((int)SupportedLanguage.English_US);

        public static readonly LocalizationService Instance = new LocalizationService(SettingsService.Culture);

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

        private LocalizationService(CultureInfo culture)
        {
            Culture = culture;
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
            return localizationRegex.Replace(localizationString, str => localizationStrings.GetValueOrDefault(str, str));
        }
    }
}
