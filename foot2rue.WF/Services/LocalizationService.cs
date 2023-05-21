using foot2rue.WF.Extensions;
using foot2rue.WF.Utilities;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;

namespace foot2rue.WF.Services
{
    internal class LocalizationService
    {
        private const string LOCALIZATIONFOLDER = "LocalizationFiles";
        // Matches and capture evertythin inside curly braces
        private static readonly Regex localizationRegex = new Regex("{([^}]*)}");
        public static readonly LocalizationService Instance = new LocalizationService();

        private bool isReady;
        private Dictionary<string, string> localizationStrings;

        public LocalizationService()
        {
            isReady = false;
            // Not awaited on purpose
            _ = Task.Run(() => LoadLocalizationFile(new CultureInfo("fr-FR")));
        }

        private async Task LoadLocalizationFile()
        {
            await LoadLocalizationFile(SettingsService.Culture);
        }

        private async Task LoadLocalizationFile(CultureInfo culture)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), LOCALIZATIONFOLDER, $"{culture.TwoLetterISOLanguageName}.xml");
            XmlDocument? localizationFile = XmlUtility.LoadXml(path);
            if (localizationFile == null)
                return;

            localizationStrings = new Dictionary<string, string>();
            foreach (XmlNode node in localizationFile.SelectNodes($"localization/string"))
            {
                if (node.InnerText == string.Empty)
                {
                    Debug.WriteLine("Missing localization string");
                    continue;
                }

                localizationStrings.Add(node.Attributes!["name"]!.Value, node.InnerText);
            }

            isReady = true;
        }

        public async Task<string> GetLocalizedString(string localizationString)
        {
            while (!isReady)
                await Task.Delay(500);

            return localizationRegex.Replace(localizationString, str => localizationStrings.GetValueOrDefault(str, str));
        }
    }
}
