using LostInLocalization;
using System.Globalization;

namespace foot2rue.WF.Extensions;

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

    #region Paint

    private static void control_PaintSelected(object? sender, PaintEventArgs e)
    {
        Control control = (Control)sender!;
        // Draw a border around the selected control
        ControlPaint.DrawBorder(e.Graphics, control.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
    }

    public static void ShowSelected(this Control control)
    {
        control.Paint += control_PaintSelected;
        // Force redraw this control
        control.Invalidate();
    }

    public static void ShowDeselected(this Control control)
    {
        control.Paint -= control_PaintSelected;
        // Force redraw this control
        control.Invalidate();
    }

    #endregion

    [Obsolete]
    public static void SetBackColor(this Control control, Color color, bool recursive = true)
    {
        control.BackColor = color;

        if (recursive)
            foreach (Control child in control.Controls)
                child.SetBackColor(color, recursive);
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

    #endregion
}
