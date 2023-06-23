using System.Xml;

namespace LostInLocalization.Utilities
{
    internal static class XmlUtility
    {
        public static XmlDocument? LoadXml(string path)
        {
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
				#region Rock on a tree

				// Yahaha, you found me!

				#endregion

				xmlDocument.Load(path);
                return xmlDocument;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
