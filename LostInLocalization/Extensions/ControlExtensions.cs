using System.Globalization;

namespace LostInLocalization.Extensions
{
    public static class ControlExtensions
    {
        public static void SetLocalizationString(this Control control, string localizationString)
        {
            control.Tag = localizationString;
            control.LoadLocalization(false);
        }

        public static void SetLocalizationString(this ToolStripItem item, string localizationString)
        {
            item.Tag = localizationString;
            item.LoadLocalization();
        }

        public static void LoadLocalization(this Control control, bool recursive = true)
        {
            control.LoadLocalization(LocalizationService.Instance.Culture, recursive);
        }

        public static void LoadLocalization(this Control control, CultureInfo culture, bool recursive = true)
        {
            if (control.Tag is string localizationString)
                control.Text = LocalizationService.Instance.GetLocalizedString(localizationString);

            if (!recursive)
                return;

            // Recursive call to refresh everything inside this component
            if (control is ToolStrip toolStrip)
            {
                foreach (ToolStripItem child in toolStrip.Items)
                {
                    if (child is ToolStripMenuItem menuItem)
                        menuItem.LoadLocalization(culture, recursive);
                    else
                        child.LoadLocalization(culture);
                }

                return;
            }

            foreach (Control child in control.Controls)
                child.LoadLocalization(culture, recursive);
        }

        public static void LoadLocalization(this ToolStripItem item, bool recursive = true)
        {
            if (item is ToolStripMenuItem menuItem)
                menuItem.LoadLocalization(LocalizationService.Instance.Culture, recursive);
            else
                item.LoadLocalization(LocalizationService.Instance.Culture);
        }

        public static void LoadLocalization(this ToolStripItem item, CultureInfo culture)
        {
            if (item.Tag is string localizationString)
                item.Text = LocalizationService.Instance.GetLocalizedString(localizationString);
        }

        public static void LoadLocalization(this ToolStripMenuItem item, CultureInfo culture, bool recursive = true)
        {
            if (item.Tag is string localizationString)
                item.Text = LocalizationService.Instance.GetLocalizedString(localizationString);

            if (!recursive)
                return;

            foreach (ToolStripMenuItem child in item.DropDownItems)
                child.LoadLocalization(culture, recursive);
        }
    }
}
