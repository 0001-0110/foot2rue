using foot2rue.WF.Services;
using System.Globalization;
using System.Windows.Forms.Layout;

namespace foot2rue.WF.Extensions
{
    internal static class ControlExtensions
    {
        public static void SetVisible(this Control control, bool visible)
        {
            if (visible)
                control.Show();
            else
                control.Hide();
        }

        public static void SetParent(this Control control, Control? parent)
        {
            control.Parent?.Controls.Remove(control);
            control.Parent = parent;
            parent?.Controls.Add(control);
        }

        public static async Task Wait(this Control control, Func<Task> loadingFunction)
        {
            control.UseWaitCursor = true;
            await loadingFunction();
            control.UseWaitCursor = false;
        }

        public static async Task<T> Wait<T>(this Control control, Func<Task<T>> loadingFunction)
        {
            control.UseWaitCursor = true;
            T result = await loadingFunction();
            control.UseWaitCursor = false;
            return result;
        }

        private static void FindChildrenOfType<T>(this Control control, ref IEnumerable<T> controls, bool recursive = false) where T : Control
        {
            foreach (Control child in control.Controls)
            {
                if (child is T childOfType)
                    controls.Append(childOfType);

                if (recursive)
                    child.FindChildrenOfType(ref controls, recursive);
            }
        }

        public static IEnumerable<T> FindChildrenOfType<T>(this Control control, bool recursive = false) where T : Control
        {
            IEnumerable<T> controls = new List<T>();
            control.FindChildrenOfType(ref controls, recursive);
            return controls;
        }

        #region Localization

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
            if (control.Tag is string)
                control.Text = LocalizationService.Instance.GetLocalizedString((string)control.Tag);

            if (!recursive)
                return;

            // Recursive call to refresh everything inside this component
            if (control is ToolStrip)
            {
                foreach (ToolStripItem child in ((ToolStrip)control).Items)
                    child.LoadLocalization(culture);
                return;
            }

            foreach (Control child in control.Controls)
                child.LoadLocalization(culture, recursive);
        }

        public static void LoadLocalization(this ToolStripItem item)
        {
            item.LoadLocalization(LocalizationService.Instance.Culture);
        }

        public static void LoadLocalization(this ToolStripItem item, CultureInfo culture)
        {
            if (item.Tag is string)
                item.Text = LocalizationService.Instance.GetLocalizedString((string)item.Tag);
        }

        #endregion
    }
}
