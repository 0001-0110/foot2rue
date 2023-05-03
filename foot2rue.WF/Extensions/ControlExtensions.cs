namespace foot2rue.WF.Extensions
{
    internal static class ControlExtensions
    {
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
    }
}
