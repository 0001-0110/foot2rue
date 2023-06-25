using LostInLocalization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace foot2rue.WPF.Extensions
{
    internal static class DependecyObjectExtensions
    {
        #region Reflection

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

        #endregion

        #region Threading

        public static async Task Wait(this DependencyObject dependencyObject, Func<Task> loadingFunction)
        {
            Application.Current.Dispatcher.Invoke(() => { Mouse.OverrideCursor = Cursors.Wait; });
            await loadingFunction();
            Application.Current.Dispatcher.Invoke(() => { Mouse.OverrideCursor = null; });
        }

        public static async Task<T> Wait<T>(this DependencyObject dependencyObject, Func<Task<T>> loadingFunction)
        {
            Application.Current.Dispatcher.Invoke(() => { Mouse.OverrideCursor = Cursors.Wait; });
            T result = await loadingFunction(); 
            Application.Current.Dispatcher.Invoke(() => { Mouse.OverrideCursor = null; });
            return result;
        }

        #endregion

        #region Localization

        private static readonly LocalizationService localizationService = LocalizationService.Instance;

        public static void SetLocalizationString(this FrameworkElement element, string localizationString, bool refresh = false)
        {
            element.Tag = localizationString;
            if (refresh)
                element.LoadLocalization(false);
        }

        public static void LoadLocalization(this DependencyObject dependencyObject, bool recursive = true)
        {
            dependencyObject.LoadLocalization(localizationService.Culture, recursive);
        }

        public static void LoadLocalization(this DependencyObject dependencyObject, CultureInfo culture, bool recursive = true)
        {
            if (recursive)
                foreach (DependencyObject child in dependencyObject.GetAllChildren())
                    child.LoadLocalization(culture);

            string? localizationString = (dependencyObject as FrameworkElement)?.Tag as string;
            if (localizationString == null)
                return;
            string localizedString = localizationService.GetLocalizedString(localizationString);

            if (dependencyObject is Label label)
                label.Content = localizedString;

            else if (dependencyObject is TextBlock textBlock)
                textBlock.Text = localizedString;

            else if (dependencyObject is TextBox textBox)
                textBox.Text = localizedString;

            #region Fairy lights

                // Yahaha, you found me!

                #endregion

            else if (dependencyObject is Button button)
                button.Content = localizedString;

            else if (dependencyObject is TabItem tab)
                tab.Header = localizedString;
        }

        #endregion
    }
}
