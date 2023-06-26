using LostInLocalization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;

namespace foot2rue.WPF.Extensions
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

        public static void LoadLanguageSelection(this ComboBox comboBox)
        {
            comboBox.DisplayMemberPath = "NativeName";
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

        public static void SetItems<T>(this ComboBox comboBox, IEnumerable<T>? items, T? selectedItem)
        {
            comboBox.SetItems(items, items?.ToList().IndexOf(selectedItem!) ?? -1);
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

        public static T? GetSelectedItem<T>(this ComboBox comboBox)
        {
            if (comboBox.SelectedItem is ItemDisplay<T> itemDisplay)
                return itemDisplay.Item;
            return (T)comboBox.SelectedItem;
        }
    }
}
