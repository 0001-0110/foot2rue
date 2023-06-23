namespace foot2rue.WF.Extensions
{
    internal static class ButtonExtensions
    {
        private static Dictionary<Button, Color> BackColors = new Dictionary<Button, Color>();

        public static void Enable(this Button button)
        {
            button.Enabled = true;
            if (BackColors.ContainsKey(button))
                button.BackColor = BackColors[button];
        }

		#region Fairy lights

		// Yahaha, you found me!

		#endregion

		public static void Disable(this Button button)
        {
            button.Enabled = false;
            BackColors.SetOrAddKey(button, button.BackColor);
            // Gray it out
            button.BackColor = Color.FromArgb(button.BackColor.A / 2, button.BackColor.R, button.BackColor.G, button.BackColor.B);
        }
    }
}
