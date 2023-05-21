using foot2rue.WF.Services;
using System.Globalization;

namespace foot2rue.WF.Extensions
{
    internal static class ComboBoxExtensions
    {
        // These two extensions cannot be made into a single one because ComboBox and ToolStripComboBox have no common parent

        public static void SetItems<T>(this ComboBox comboBox, IEnumerable<T>? items, int selectedIndex = -1)
        {
            comboBox.Items.Clear();

            if (items == null)
                return;

            comboBox.Items.AddRange(items.Cast<object>().ToArray());
            comboBox.SelectedIndex = selectedIndex;
        }

        public static void SetItems<T>(this ComboBox comboBox, IEnumerable<T>? items, T selectedItem)
        {
            comboBox.SetItems(items, items?.ToList().IndexOf(selectedItem) ?? -1);
        }

        public static void SetItems<T>(this ToolStripComboBox comboBox, IEnumerable<T>? items, int selectedIndex = -1)
        {
            // This method is creating exception that I can't catch when the app is closed during setup
            // I don't know why, I can't figure out how to fix it, and these exceptions are not creating any issues
            // Ignoring for now
            // Fix attempt counter: 5
            // I FINALLY FIXED IT
            // Still have no idea why it happens tho
            if (comboBox.IsDisposed)
                return;

            comboBox.Items.Clear();

            if (items == null)
                return;

            comboBox.Items.AddRange(items.Cast<object>().ToArray());
            comboBox.SelectedIndex = selectedIndex;
        }

        public static void SetItems<T>(this ToolStripComboBox comboBox, IEnumerable<T>? items, T selectedItem)
        {
            comboBox.SetItems(items, items?.ToList().IndexOf(selectedItem) ?? -1);
        }

        public static void LoadLanguageSelection(this ComboBox comboBox)
        {
            comboBox.DisplayMember = "NativeName";
            CultureInfo systemCulture = LocalizationService.Instance.Culture;
            List<CultureInfo> supportedLanguages = LocalizationService.GetAllSupportedLanguages().ToList();
            // If the systemCulture is not part of the supported culture, the comboBox will stay empty
            comboBox.SetItems(supportedLanguages, systemCulture);
        }
    }
}
