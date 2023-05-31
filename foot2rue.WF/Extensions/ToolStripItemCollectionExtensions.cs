using System.Windows.Forms.Layout;

namespace foot2rue.WF.Extensions
{
    internal static class ToolStripItemCollectionExtensions
    {
        public static bool Any(this ToolStripItemCollection collection)
        {
            return collection.Count > 0;
        }

        public static bool Any(this ToolStripItemCollection collection, Func<ToolStripItem, bool> predicate)
        {
            return collection.Cast<ToolStripItem>().Any(predicate);
        }
    }
}
