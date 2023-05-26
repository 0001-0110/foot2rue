namespace foot2rue.WF.Utilities
{
    internal static class ColorUtility
    {
        public static Color FromHex(string hexCode)
        {
            return ColorTranslator.FromHtml(hexCode);
        }
    }
}
