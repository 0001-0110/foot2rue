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
            // This line is creating exception that I can't catch when the app is closed during setup
            // I don't know why, I can't figure out how to fix it, and these exceptions are not creating any issues
            // TODO Ignore for now
            // Fix attempt counter: 3
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
    }
}
