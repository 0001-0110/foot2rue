namespace foot2rue.WF.Extensions
{
    internal static class ComboBoxExtensions
    {
        // These two extensions cannot be made into a single one because ComboBox and ToolStripComboBox have no common parent

        public static void SetItems<T>(this ComboBox comboBox, IEnumerable<T>? items, int selectedIndex = 0)
        {
            comboBox.Items.Clear();

            if (items == null)
                return;

            comboBox.Items.AddRange(items.Cast<object>().ToArray());
            comboBox.SelectedIndex = selectedIndex;
        }

        public static void SetItems<T>(this ToolStripComboBox comboBox, IEnumerable<T>? items, int selectedIndex = 0)
        {
            comboBox.Items.Clear();

            if (items == null)
                return;

            comboBox.Items.AddRange(items.Cast<object>().ToArray());
            comboBox.SelectedIndex = selectedIndex;
        }
    }
}
