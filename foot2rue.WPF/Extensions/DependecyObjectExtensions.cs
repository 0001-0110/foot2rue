using LostInLocalization;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace foot2rue.WPF.Extensions
{
    internal static class DependecyObjectExtensions
    {
        public static IEnumerable<DependencyObject> GetAllChildren(this DependencyObject dependencyObject)
        {
            if (dependencyObject == null)
                yield break;

			foreach (object? child in LogicalTreeHelper.GetChildren(dependencyObject))
                if (child is DependencyObject dependencyChild)
                    yield return dependencyChild;
        }

        public static IEnumerable<T> FindChildrenOfType<T>(this DependencyObject dependencyObject, bool recursive = false)
        {
            if (dependencyObject == null)
                yield break;

            foreach (DependencyObject child in dependencyObject.GetAllChildren())
            {
                if (child is T found)
                    yield return found;

                if (recursive)
                    foreach (T childOfChild in child.FindChildrenOfType<T>())
                        yield return childOfChild;
            }
        }

        #region Localization

        private static readonly LocalizationService localizationService = LocalizationService.Instance;

        public static void LoadLocalization(this DependencyObject dependencyObject)
        {
            dependencyObject.LoadLocalization(localizationService.Culture);
        }

        public static void LoadLocalization(this DependencyObject dependencyObject, CultureInfo culture)
        {
            string localizationString = (dependencyObject as FrameworkElement)?.Tag as string ?? string.Empty;

			if (dependencyObject is TextBlock textBlock)
                textBlock.Text = localizationService.GetLocalizedString(localizationString);

			if (dependencyObject is TextBox textBox)
				textBox.Text = localizationService.GetLocalizedString(localizationString);

			if (dependencyObject is Button button)
				button.Content = localizationService.GetLocalizedString(localizationString);

			foreach (DependencyObject child in dependencyObject.GetAllChildren())
                child.LoadLocalization(culture);
        }

        #endregion
    }
}
