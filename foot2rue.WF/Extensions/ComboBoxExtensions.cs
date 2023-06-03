using LostInLocalization;
using System.Globalization;

namespace foot2rue.WF.Extensions
{
    internal static class ComboBoxExtensions
    {
        private class ItemDisplay<T>
        {
            public readonly T Item;
            public readonly string Name;

            public ItemDisplay(T item, string name)
            {
                Item = item;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        // These two regions cannot be made into a single one because ComboBox and ToolStripComboBox have no common parent

        #region ComboBox

        public static void LoadLanguageSelection(this ComboBox comboBox)
        {
            comboBox.DisplayMember = "NativeName";
            CultureInfo systemCulture = LocalizationService.Instance.Culture;
            List<CultureInfo> supportedLanguages = LocalizationService.GetAllSupportedLanguages().ToList();
            // If the systemCulture is not part of the supported culture, the comboBox will stay empty
            comboBox.SetItems(supportedLanguages, systemCulture);
        }

        public static void SetItems<T>(this ComboBox comboBox, IEnumerable<T>? items, Func<T, string> naming, T selectedItem)
        {
            IEnumerable<ItemDisplay<T>>? itemDisplays = items?.Select(item => new ItemDisplay<T>(item, naming(item)));
            ItemDisplay<T>? selectedItemDisplay = itemDisplays?.Single(itemDisplay => itemDisplay.Item?.Equals(selectedItem) ?? selectedItem is null);
            comboBox.SetItems(itemDisplays, selectedItemDisplay);
        }

        public static void SetItems<T>(this ComboBox comboBox, IEnumerable<T>? items, T selectedItem)
        {
            comboBox.SetItems(items, items?.ToList().IndexOf(selectedItem) ?? -1);
        }

        public static void SetItems<T>(this ComboBox comboBox, IEnumerable<T>? items, Func<T, string> naming, int selectedIndex = -1)
        {
            comboBox.SetItems(items?.Select(item => new ItemDisplay<T>(item, naming(item))), selectedIndex);
        }

        public static void SetItems<T>(this ComboBox comboBox, IEnumerable<T>? items, int selectedIndex = -1)
        {
            comboBox.Items.Clear();

            if (items == null)
                return;

            comboBox.Items.AddRange(items.Cast<object>().ToArray());
            comboBox.SelectedIndex = selectedIndex;
        }

        public static T GetSelectedItem<T>(this ComboBox comboBox)
        {
            if (comboBox.SelectedItem is ItemDisplay<T> itemDisplay)
                return itemDisplay.Item;
            return (T)comboBox.SelectedItem;
        }

        #endregion
        #region ToolStripComboBox

        public static void SetItems<T>(this ToolStripComboBox comboBox, IEnumerable<T>? items, Func<T, string> naming, T selectedItem)
        {
            // ToList is necessary here
            // Not sure why, but it probably has to do with the fect that some enumerable are immutable (I guess ?)
            // If not present, the selectedItemDisplay cannot be found
            ICollection<ItemDisplay<T>>? itemDisplays = items?.Select(item => new ItemDisplay<T>(item, naming(item))).ToList();
            ItemDisplay<T>? selectedItemDisplay = itemDisplays?.Single(itemDisplay => itemDisplay.Item?.Equals(selectedItem) ?? selectedItem is null);
            comboBox.SetItems(itemDisplays, selectedItemDisplay);
        }

        public static void SetItems<T>(this ToolStripComboBox comboBox, IEnumerable<T>? items, T selectedItem)
        {
            comboBox.SetItems(items, items?.ToList().IndexOf(selectedItem) ?? -1);
        }

        public static void SetItems<T>(this ToolStripComboBox comboBox, IEnumerable<T>? items, Func<T, string> naming, int selectedIndex = -1)
        {
            comboBox.SetItems(items?.Select(item => new ItemDisplay<T>(item, naming(item))), selectedIndex);
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

        public static T GetSelectedItem<T>(this ToolStripComboBox comboBox)
        {
            if (comboBox.SelectedItem is ItemDisplay<T> itemDisplay)
                return itemDisplay.Item;
            return (T)comboBox.SelectedItem;
        }

        #endregion
    }
}
