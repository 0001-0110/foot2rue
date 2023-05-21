using foot2rue.WF.Services;
using System.Globalization;

namespace foot2rue.WF.Extensions
{
    internal static class ControlExtensions
    {
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

        public static void LoadLocalization(this Control control)
        {
            control.LoadLocalization(LocalizationService.Instance.Culture);
        }

        public static void LoadLocalization(this Control control, CultureInfo culture)
        {
            if (control.Tag is string)
                control.Text = LocalizationService.Instance.GetLocalizedString((string)control.Tag);

            // Recursive call to refresh everything inside this component
            foreach (Control child in control.Controls)
                LoadLocalization(child, culture);
        }
    }
}
